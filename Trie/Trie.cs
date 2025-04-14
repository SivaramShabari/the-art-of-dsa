/* 
🌳 Trie Data Structure in C#
Built for blazing-fast prefix and word lookups 🔥
Supports insertions and search (with optional prefix mode)
Each node is a character checkpoint — classic "choose your own adventure" style
Warning: May cause you to love dictionaries more than you should 😄
*/

namespace DSA.Trie;
public class Trie
{
    private readonly TrieNode Root = new();

    public void InsertWord(string word)
    {
        var currentNode = Root;
        foreach (var character in word)
        {
            if (currentNode.children.TryGetValue(character, out var node))
                currentNode = node;
            else
            {
                currentNode[character] = new();
                currentNode = currentNode[character];
            }
        }
        currentNode.isEndOfWord = true;
    }

    public bool IsValidWord(string word, bool isPrefix = false)
    {
        var currentNode = Root;
        foreach (var character in word)
        {
            if (!currentNode.children.TryGetValue(character, out var node))
                return false;
            else
                currentNode = node;
        }
        if (isPrefix) return true;
        return currentNode.isEndOfWord;
    }
}

public class TrieNode
{
    public Dictionary<char, TrieNode> children = new();
    public bool isEndOfWord = false;
}