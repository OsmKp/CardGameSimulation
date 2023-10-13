namespace BlackJack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many players? > ");
            int numOfPlayers = int.Parse(Console.ReadLine());
            List<Player> playerList = new List<Player>();

            for (int plrNo = 1; plrNo <= numOfPlayers; plrNo++)
            {
                Console.WriteLine("Enter Player " + plrNo + "'s hand inputting the card at the top first, For e.g 'Q,Q,10,5,J' > ");
                string plrHand = Console.ReadLine();
                Hand playerHand = GetHandFromString(plrHand);
                Player player = new Player(playerHand, plrNo.ToString());
                playerList.Add(player);

            }

            MiddleStack MiddleStack = new MiddleStack();

            Game Game1 = new Game(MiddleStack, playerList);
            Game1.Start();
        }

        public static Hand GetHandFromString(string input)
        {
            Hand hand = new Hand(input);
            return hand;

        }
    }
}