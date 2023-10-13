using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    internal class Game
    {

        public enum GameState
        {
            Normal,
            Special

        }
        private MiddleStack middleStack;
        private List<Player> playerList;
        private Player currentPlayer;
        private Player? playerToCollectCards;
        private int turnCount;
        private bool gameEnded;
        private GameState gameState;
        private int chancesBeforeCollection;
        public Game(MiddleStack middleStack, List<Player> playerList) { 
            this.playerList = playerList;
            this.middleStack = middleStack;
            turnCount = 1;
            gameEnded = false;
            gameState = GameState.Normal;
            currentPlayer = playerList[0];
            playerToCollectCards = null;
            chancesBeforeCollection = -1;
        }

        public void Start()
        {
            Console.WriteLine("-----------------------------------------------------------------------------");
            while(gameEnded == false)
            {
                if (playerList.Count == 1)
                {
                    gameEnded = true;
                    break;
                }
                //check if player has card first
                Console.WriteLine("---------------------- NEW TURN STARING --------------------- " + turnCount);
                Console.WriteLine("--------------- GENERAL INFO");
                Console.WriteLine("Middle stack from top to bottom: " + middleStack.OutputMiddleStack());
                if (playerToCollectCards != null)
                {
                    Console.WriteLine("Player to collect cards is: " + playerToCollectCards.name);
                }
                Console.WriteLine("--------------- CURRENT PLAYER INFO");
                Console.WriteLine("Current player is: " + currentPlayer.name);
                Console.WriteLine("Current player has "+ currentPlayer.GetHandSize() + " cards");
                Console.WriteLine("Current player's hand is: " + currentPlayer.OutputHand());
                Console.WriteLine("---------------");

                bool hasPlayerRunOutOfCards = currentPlayer.HasPlayerLost();
                if(hasPlayerRunOutOfCards )
                {
                    playerList.Remove(currentPlayer);
                }


                bool collectionHappened = false;
                if(hasPlayerRunOutOfCards != true) {
                    if (gameState == GameState.Normal) {  PlayTurnForNormalState(); }
                    else {collectionHappened = PlayTurnForSpecialState(); }
                }

                turnCount++;   
                
                if (collectionHappened == false)
                {
                    Console.WriteLine("Collection did not happen this turn");
                    currentPlayer = playerList[GetIndexOfNextPlayer()];
                }
                else { Console.WriteLine("Collection did happen this turn!!"); }

            }
            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Game is Over!");
            Console.WriteLine("The winner is: "+ currentPlayer.name);
        }

        public bool PlayTurnForSpecialState()
        {
            
            bool playerSaved = false;
            ICard cardPlayed;
            while(chancesBeforeCollection > 0 && playerSaved == false)
            {
                bool playerRanOutOfCards = currentPlayer.HasPlayerLost();
                if(playerRanOutOfCards)
                {

                    return false;

                }

                cardPlayed = currentPlayer.PlayCard();
                Console.WriteLine("Player " + currentPlayer.name + " plays " + cardPlayed.Value);
                middleStack.AddToMiddle(cardPlayed);
                chancesBeforeCollection--;

                if(cardPlayed is SpecialCard)
                {
                    chancesBeforeCollection = (int)Enum.Parse(typeof(SpecialCardIndex), cardPlayed.Value);
                    playerSaved = true;
                    playerToCollectCards = currentPlayer;
                }
                else
                {
                    
                }

            }
            
            if(playerSaved == false)
            {
                currentPlayer = playerToCollectCards;
                playerToCollectCards.AddCards(middleStack.TakeMiddleStack());
                playerToCollectCards = null;
                chancesBeforeCollection = -1;
                gameState = GameState.Normal;
                
                return true;
            }
            return false;
        }

        public void PlayTurnForNormalState()
        {
            
            ICard cardPlayed = currentPlayer.PlayCard();
            middleStack.AddToMiddle(cardPlayed);
            Console.WriteLine("Player " + currentPlayer.name + " plays " + cardPlayed.Value);
            if (cardPlayed is SpecialCard)
            {
                gameState = GameState.Special;
                chancesBeforeCollection = (int)Enum.Parse(typeof(SpecialCardIndex), cardPlayed.Value);
                playerToCollectCards = currentPlayer;
            }
        }

        public int GetIndexOfNextPlayer()
        {
            
            int currentIndex = playerList.IndexOf(currentPlayer);
            //Console.WriteLine("Current index is: " + currentIndex);
            int nextIndex = currentIndex + 1;
            //Console.WriteLine("Next index is: " + nextIndex);
            if(nextIndex< playerList.Count)
            {
                
                return nextIndex;
            }
            else
            {
                //Console.WriteLine("Returning 0");
                return 0;
            }
        }

    }
}
