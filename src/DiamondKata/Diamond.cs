using System.Text.RegularExpressions;

namespace DiamondKata;

public class Diamond
{
    private char _letter;
    private char _spaceChar;

    private readonly char newLineChar = '\n'; 
    private readonly char[] alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();

    public Diamond(char letter, char spaceChar = ' ')
    {
        if (!Regex.IsMatch(letter.ToString(), "[a-z]", RegexOptions.IgnoreCase))
            throw new ArgumentException("Invalid letter");

        _letter = char.ToUpper(letter);
        _spaceChar = spaceChar;
    }

    private IEnumerable<string> GetDiamondRows()
    {
        var rows = new List<string>();

        // Credit https://stackoverflow.com/questions/20044730/convert-character-to-its-alphabet-integer-position/20044767#20044767
        var letterAlphabetArrayPosition = _letter - 64 - 1; // -1 because we want a zero based index

        var colCount = (2 * letterAlphabetArrayPosition) + 1;

        for (int i = 0; i <= letterAlphabetArrayPosition; i++) // Up to and including the _letter
        {
            var row = GetDiamondRow(i, colCount);

            rows.Add(row);
        }

        for (int i = rows.Count - 2; i >= 0; i--)
        {
            var row = rows[i];

            rows.Add(row);
        }

        return rows;
    }

    private string GetDiamondRow(int rowLetterPosition, int colCount)
    {
        var rowLetter = alphabet[rowLetterPosition];
        var rowLetterCount = rowLetterPosition == 0 ? 1 : 2;
        var internalSpaceCount = rowLetterPosition == 0 ? 0 : 2 * rowLetterPosition - 1;
        var paddingSpaceCount = (colCount - rowLetterCount - internalSpaceCount) / 2;

        var paddingSpaces = GetSpaces(paddingSpaceCount);

        if (rowLetterCount == 1)
            return $"{paddingSpaces}{rowLetter}{paddingSpaces}";

        var internalSpaces = GetSpaces(internalSpaceCount);

        return $"{paddingSpaces}{rowLetter}{internalSpaces}{rowLetter}{paddingSpaces}";
    }

    private string GetSpaces(int spaceCount)
    {
        return new string(_spaceChar, spaceCount);
    }

    public override string ToString()
    {
        return string.Join(newLineChar, GetDiamondRows());
    }
}