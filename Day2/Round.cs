namespace Day2
{
    enum ChosenFigure
    {
        Rock,
        Paper,
        Scissors
    }
    internal class Round
    {
        ChosenFigure oponent;
        ChosenFigure player;
        int playerScore;
        public Round(char oponent, char player)
        {
            switch(oponent)
            {
                case 'A':
                    this.oponent = ChosenFigure.Rock;
                    break;
                case 'B':
                    this.oponent = ChosenFigure.Paper;
                    break;
                case 'C':
                    this.oponent = ChosenFigure.Scissors;
                    break;
            }
            switch (player)
            {
                case 'X':
                    this.player = ChosenFigure.Rock;
                    break;
                case 'Y':
                    this.player = ChosenFigure.Paper;
                    break;
                case 'Z':
                    this.player = ChosenFigure.Scissors;
                    break;
            }
            playerScore = MatchResultPoints();
        }

        public Round(char oponent, ChosenFigure player)
        {
            switch (oponent)
            {
                case 'A':
                    this.oponent = ChosenFigure.Rock;
                    break;
                case 'B':
                    this.oponent = ChosenFigure.Paper;
                    break;
                case 'C':
                    this.oponent = ChosenFigure.Scissors;
                    break;
            }
            this.player = player;
            playerScore = MatchResultPoints();
        }

        public int PlayerScore
        {
            get 
            { 
                return playerScore; 
            }
        }
        int MatchResultPoints()
        {
            switch(player)
            {
                //add 1 to every return
                case ChosenFigure.Rock:
                    switch(oponent)
                    {
                        case ChosenFigure.Rock:
                            return 4;
                        case ChosenFigure.Paper:
                            return 1;
                        case ChosenFigure.Scissors:
                            return 7;
                    }
                    break;
                //add 2 in every return
                case ChosenFigure.Paper:
                    switch (oponent)
                    {
                        case ChosenFigure.Rock:
                            return 8;
                        case ChosenFigure.Paper:
                            return 5;
                        case ChosenFigure.Scissors:
                            return 2;
                    }
                    break;
                //add 3 in every return
                case ChosenFigure.Scissors:
                    switch (oponent)
                    {
                        case ChosenFigure.Rock:
                            return 3;
                        case ChosenFigure.Paper:
                            return 9;
                        case ChosenFigure.Scissors:
                            return 6;
                    }
                    break;
            }
            return 0;
        }
    }
}
