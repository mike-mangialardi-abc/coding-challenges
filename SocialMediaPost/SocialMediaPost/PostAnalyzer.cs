namespace SocialMediaPost
{
    /*
     * A social media company needs to analyze posts, and your job is to create a class called PostAnalyzer to perform that task. This class should accept a social media post (in the form of a string)
     * in its constructor and provide two methods to analyze the post: one method will return the number of distinct words contained in the post, and the other method will return the number of times a
     * specified word appears in the post. The post will contain only letters, numbers, whitespace characters ,and the following punctuation marks: ! . , * - ?
     * 
     * A shell of the PostAnalyzer class is provided for you, and your job is to implement the following methods:
     * - GetIndividualWordCount(string word): Get the word count for the input word (the example below has 2 occurrences of the word "the")
     * - GetDistinctWordCount(): Get the total number of distinct words (the example below has 7 distinct words)
`    *
     * Example: "The brown dog barked at the young boy."
     * - GetDistinctWordCount() => 7
     * - GetIndividualWordCount("the") => 2
     *
     * Helpful Hints:
     * - Think about what data structure to store the post so that it is easy to determine the distinct word count and the individual word counts
     * - The wordDelimiters are already provided
     */
    public class PostAnalyzer
    {
        private readonly char[] _wordDelimiters = { ' ', '!', '.', ',', '*', '-', '?' };
        private readonly string _post;

        // TODO: Add your private fields here!

        public PostAnalyzer(string post)
        {
            _post = post;
        }

        // Returns the total number of distinct words
        public int GetDistinctWordCount()
        {
            return 0; // TODO: Your Code Here!
        }

        // Determine how many times a word appears in the post, given a word
        public int GetIndividualWordCount(string word)
        {
            return 0; // TODO: Your Code Here!
        }
    }
}
