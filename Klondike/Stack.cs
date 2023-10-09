namespace Klondike;

internal class Stack
{
    public List<Card> stackedCards;
    public int numberOfCards;
    public Position position;
    public int positionX, positionY;
    public int firstCardNumber;

    private protected Card emptyCard = new((Suit)(-1), (Value)(-1), true);

    public Stack(Card[] cards, int numberOfCards, int firstCardNumber, int position)
    {
        this.numberOfCards = numberOfCards;
        this.position = (Position)position;
        this.firstCardNumber = firstCardNumber;
        stackedCards = new List<Card>();

        if (position >= 0 && position <= 7)
        {
            positionX = (position - 1) * Card.renderWidth + position - 1;
            positionY = 2 * Card.renderHeight;
        }
        else if (position >= 10)
        {
            positionX = (position / 10 + 1) * Card.renderWidth + 11 + (int)position / 10;
            positionY = 0 * Card.renderHeight;
        }
        else
        {
            positionX = 0;
            positionY = 0;
        }

        for (int i = firstCardNumber; i < firstCardNumber + numberOfCards; i++)
        {
            Card card = cards[i];
            card.faceUp = (i == firstCardNumber + numberOfCards - 1 && position != 0);
            stackedCards.Add(card);
        }



    }

    public Card GetCard(int positionOfCard)
    {
        if (stackedCards.Count > 0)
        {
            Card card = stackedCards[positionOfCard];
            return card;
        }

        return emptyCard;
    }

    public Card GetFirstCard()
    {
        if (numberOfCards > 0)
        {
            // ???
            return stackedCards[numberOfCards - 1];
        }
        return stackedCards[0];
    }

    public Card GetLastCard()
    {
        return stackedCards.Last<Card>();
    }

    /* Not used
    public void TurnCard(Card card)
    {
        card.faceUp = !(card.faceUp);
    }
    */

    public void AddCard(Card card)
    {
        if (stackedCards.Count > 0 && numberOfCards == 0)
        {
            stackedCards.Remove(emptyCard);
        }

        if (numberOfCards > 0)
        {
            stackedCards.Last<Card>().faceUp = true;
        }

        stackedCards.Add(card);
        stackedCards.Last<Card>().faceUp = true;
        numberOfCards++;
    }

    public void RemoveCard(Card card)
    {

        if (numberOfCards > 0)
        {
            stackedCards.Remove(card);
            numberOfCards--;
            if (numberOfCards == 0)
            {
                stackedCards.Add(emptyCard);
                emptyCard.faceUp = true;

            }
            else
            {
                stackedCards.Last<Card>().faceUp = true;
            }

        }
        else if (numberOfCards == 0 && stackedCards.Count > 0)
        {
            stackedCards = new ();
            //stackedCards.Remove(card);
            stackedCards.Add(emptyCard);

        }
    }
}