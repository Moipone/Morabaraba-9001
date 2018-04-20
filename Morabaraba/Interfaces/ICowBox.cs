namespace Morabaraba
{
    public interface ICowBox
    {
        ITile takeCow(Symbol sym);
        int remainingCows(Symbol sym);

        int cowsRemainingOnBoard(Symbol sym);
    }
}