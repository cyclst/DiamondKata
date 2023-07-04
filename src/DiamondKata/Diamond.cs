namespace DiamondKata;

public class Diamond
{
    private char _letter;

    public Diamond(char letter)
    {
        _letter = letter;
    }

    public override string ToString()
    {
        return _letter.ToString();
    }
}