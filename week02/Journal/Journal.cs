using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine();
        }
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter outputFile = new StreamWriter(file))
        {
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine($"{entry._date}~|~{entry._promptText}~|~{entry._entryText}");
            }
        }

        Console.WriteLine($"File {file} saved succesfully!");
        Console.WriteLine();
    }
    public void LoadFromFile(string file)
    {

        _entries.Clear();

        string[] lines = File.ReadAllLines(file);

        foreach (string line in lines)
        {
            string[] parts = line.Split("~|~");

            string lineDate = parts[0];
            string linePrompt = parts[1];
            string lineText = parts[2];

            Entry lineEntry = new Entry();
            lineEntry._date = lineDate;
            lineEntry._promptText = linePrompt;
            lineEntry._entryText = lineText;

            AddEntry(lineEntry);
        }

        Console.WriteLine($"File {file} loaded succesfully!");
        Console.WriteLine();
    }
}