
/// <summary>
/// This queue is circular. When people are added via AddPerson, they are
/// added to the back of the queue according to FIFO rules.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add a person to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Return the next person. People with turns remaining are re-enqueued.
    /// A turns value of zero or less means infinite turns.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        Person person = _people.Dequeue();

        if (person.Turns <= 0)
        {
            // Infinite turns: keep the original turns value.
            _people.Enqueue(person);
        }
        else if (person.Turns > 1)
        {
            // Finite turns: decrement and re-enqueue if turns remain.
            person.Turns--;
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
