using Scripts.Abstarct;
using UniRx;

public class WalletAccount : IModel
{
    public ReactiveProperty<int> GoldValue { get; } = new ReactiveProperty<int>();

    public void ChangeGold(int value)
    {
        GoldValue.Value += value;
    }
}