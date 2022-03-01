namespace Memento;

//Also we can save commands instead of memento tokens
public class BankAccount
{
    private int _balance;
    private IList<Memento> _changes = new List<Memento>();
    private int _current;
    public BankAccount(int balance)
    {
        _balance = balance;
        _changes.Add(new Memento(_balance));
        _current = 0;
    }

    public Memento Deposit(int amount)
    {
        _balance += amount;
        var m = new Memento(_balance);
        _changes.Add(m);
        _current++;

        return m;
    }

    public void RestoreTo(Memento? memento)
    {
        if (memento is not null)
        {
            _balance = memento.Balance;
            _changes.Add(memento);
            _current = _changes.Count - 1;
        }
    }

    public Memento? Undo()
    {
        if (_current > 0)
        {
            var m = _changes[--_current];
            _balance = m.Balance;
            
            return m;
        }

        return null;
    }

    public Memento? Redo()
    {
        if (_current < _changes.Count - 1)
        {
            var m = _changes[++_current];
            _balance = m.Balance;

            return m;
        }

        return null;
    }

    public override string ToString()
    {
        return $"Balance: {_balance}";
    }
}

public class Memento
{
    public int Balance { get; }

    public Memento(int balance)
    {
        Balance = balance;
    }
}