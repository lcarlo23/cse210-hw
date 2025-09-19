public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] words = text.Split(' ');

        foreach (string textWord in words)
        {
            Word word = new Word(textWord);
            _words.Add(word);
        }
    }

    public void HideRandomWords(int numberToHide)
    {
        int count = 0;
        int attempts = 0;
        Random random = new Random();

        while (count < numberToHide && attempts < (_words.Count * 3))
        {
            int index = random.Next(_words.Count);
            if (!_words[index].isHidden())
            {
                _words[index].Hide();
                count++;
            }
            attempts++;
        }
    }
    public string GetDisplayText()
    {
        List<string> words = new List<string>();

        foreach (Word word in _words)
        {
            string text = word.GetDisplayText();
            words.Add(text);
        }

        string fullString = string.Join(" ", words);
        return $"{_reference.GetDisplayText()}\n{fullString}";
    }
    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }

        return true;
    }
}