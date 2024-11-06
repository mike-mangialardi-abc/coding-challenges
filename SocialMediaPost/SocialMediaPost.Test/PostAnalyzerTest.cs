namespace SocialMediaPost.Test;

[TestClass]
    public class PostAnalyzerTest
    {
        [TestMethod]
        [DataRow("The way to get started is to quit talking and begin doing", 11, "quit", 1)]
        [DataRow("The way to get started is to quit talking and begin doing", 11, "to", 2)]
        public void VerifySimplePosts(string post, int totalDistinctWordCount, string word, int individualWordCount)
        {
            var postAnalyzer = new PostAnalyzer(post);
            Assert.AreEqual(totalDistinctWordCount, postAnalyzer.GetDistinctWordCount());
            Assert.AreEqual(individualWordCount, postAnalyzer.GetIndividualWordCount(word));
        }

        [TestMethod]
        [DataRow("Your time is limited, so don't waste it living someone else's life. Don't be trapped by dogma which is living with the results of other people's thinking.", 24, "don't", 2)]
        [DataRow("O Romeo, Romeo, wherefore art thou Romeo? Deny thy father and refuse thy name; Or if thou wilt not, be but sworn my love And I�ll no longer be a Capulet", 25, "romeo", 3)]
        public void VerifyMediumPosts(string post, int totalDistinctWordCount, string word, int individualWordCount)
        {
            var postAnalyzer = new PostAnalyzer(post);
            Assert.AreEqual(totalDistinctWordCount, postAnalyzer.GetDistinctWordCount());
            Assert.AreEqual(individualWordCount, postAnalyzer.GetIndividualWordCount(word));
        }

        [TestMethod]
        [DataRow("In its second minute the Hate rose to a frenzy. People were leaping up and down in their places and shouting at the tops of their voices in an effort to drown the maddening bleating voice that came from the screen. The little sandy-haired woman had turned bright pink, and her mouth was opening and shutting like that of a landed fish. Even O�Brien�s heavy face was flushed. He was sitting very straight in his chair, his powerful chest swelling and quivering as though he were standing up to the assault of a wave. The dark-haired girl behind Winston had begun crying out Swine! Swine! Swine! and suddenly she picked up a heavy Newspeak dictionary and flung it at the screen. It struck Goldstein�s nose and bounced off; the voice continued inexorably. In a lucid moment Winston found that he was shouting with the others and kicking his heel violently against the rung of his chair. The horrible thing about the Two Minutes Hate was not that one was obliged to act a part, but, on the contrary, that it was impossible to avoid joining in. Within thirty seconds any pretence was always unnecessary. A hideous ecstasy of fear and vindictiveness, a desire to kill, to torture, to smash faces in with a sledge-hammer, seemed to flow through the whole group of people like an electric current, turning one even against one�s will into a grimacing, screaming lunatic. And yet the rage that one felt was an abstract, undirected emotion which could be switched from one object to another like the flame of a blowlamp", 163, "a", 11)]
        [DataRow("Here she comes now sayin' Mony Mony Shoot 'em down, turn around, come on Mony Hey! She give me love and I feel alright now Turn it in You gotta toss and turn and feel alright Yeah, I feel alright I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah 'Cause you make me feel like a pony So good like a pony So good like a pony So good Mony Mony So fine Mony Mony So fine Mony Mony It's all mine Mony Mony Well, I feel alright Mony Mony I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah, yeah yeah Well, you could shake it, Mony Mony Shotgun dead and I'll come on Mony Don't stop cookin' 'cause I feel all right now, ehi! But don't stop now, come on Mony, come on, yeah I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah 'Cause you make me feel like a pony So good like a pony So good like a pony Well, I feel alright You so fine Mony Mony You so fine Mony Mony You so fine Mony Mony And I feel alright I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah, yeah yeah Ooh, I love you Mony Mo-Mo-Mony Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Say I do Ooh, I love you Mony Mo-Mo-Mony Yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah, yeah yeah Come on, come on, come on, come on Come on, come on, come on, come on Come on, come on feel alright come on I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah, yeah yeah Wake it, shake it Mony Mony Up, down, turn around, come on Mony Hey! She give me love and I feel alright now I said don't stop now, come on Mony Come on Mony I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah 'Cause you make me feel like a pony So good like a pony So good like a pony So good like a pony Feel alright Mony Mony Alright Mony Mony So fine Mony Mony Well, I feel alright Mony Mony I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah I wanna ride your pony Ride your pony, ride your pony Come on, come on, come on! Mony Mony Mony Mony Feel alright Mony Mony Mony, Mony I said yeah yeah, yeah yeah Yeah yeah, yeah yeah, yeah yeah 'Cause you make me feel like a pony So good like a pony So good like a pony So good Come on! Mony Mony, yeah Mony Mony, alright Mony Mony Well, I feel so good Mony Mony I said yeah yeah, yeah yeah, yeah Yeah, yeah, yeah, yeah, yeah yeah", 60, "yeah", 110)]
        public void VerifyDifficultPosts(string post, int totalDistinctWordCount, string word, int individualWordCount)
        {
            var postAnalyzer = new PostAnalyzer(post);
            Assert.AreEqual(totalDistinctWordCount, postAnalyzer.GetDistinctWordCount());
            Assert.AreEqual(individualWordCount, postAnalyzer.GetIndividualWordCount(word));
        }
    }
