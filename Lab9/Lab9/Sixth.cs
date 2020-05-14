using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Lab9
{
    /*
    Представить турнирную сетку раунда плей-офф чемпионата мира в виде
    дерева. Названия команд считать из файла либо «прошить» в коде. Сначала
    корень дерева и все узлы, кроме листьев, заполнить пустыми строками и
    неизвестными результатами. Листья соответствуют матчам этапа 1/16
    финала. Результаты матчей генерировать произвольным образом, продвигая
    команд-победителей от листьев к корню.
    */
    public class Sixth
    {
        class BinaryTreeNode
        {
            public Game data;
            public BinaryTreeNode left = null;
            public BinaryTreeNode right = null;
        }
        class BinaryTree
        {
            BinaryTreeNode root = null;
            public BinaryTreeNode AddRoot(Game elem)
            {
                root = new BinaryTreeNode { data = elem };
                return root;
            }
            public BinaryTreeNode AddLeft(BinaryTreeNode node, Game elem)
            {
                var newNode = new BinaryTreeNode { data = elem };
                node.left = newNode;
                return newNode;
            }
            public BinaryTreeNode AddRight(BinaryTreeNode node, Game elem)
            {
                var newNode = new BinaryTreeNode { data = elem };
                node.right = newNode;
                return newNode;
            }
            public void InOrder(BinaryTreeNode node, int level = 0)
            {
                if (node != null)
                {
                    InOrder(node.left, level + 1);
                    for (int i = 0; i < level; i++)
                        Console.Write("     ");
                    Console.WriteLine(node.data.MakeString() + "\n");
                    InOrder(node.right, level + 1);
                }
            }
            public void InOrderTraversal()
            {
                InOrder(root);
            }
        }
        struct Game
        {
            public string firstTeam, secondTeam;
            public int firstScore, secondScore;
            public string MakeString()
            {
                return (firstTeam + " - " + secondTeam + " : " + firstScore + " - " + secondScore);
            }
        }
        static Game NextGame(Game firstGame, Game secondGame)
        {
            string newFirstTeam = "";
            string newSecondTeam = "";
            Random rand = new Random();

            if (firstGame.firstScore >= firstGame.secondScore)
                newFirstTeam = firstGame.firstTeam;

            else
                newFirstTeam = firstGame.secondTeam;

            if (secondGame.firstScore >= secondGame.secondScore)
                newSecondTeam = secondGame.firstTeam;
            else
                newSecondTeam = secondGame.secondTeam;

            Game newGame = new Game();
            newGame.firstTeam = newFirstTeam;
            newGame.secondTeam = newSecondTeam;
            newGame.firstScore = rand.Next(0, 5);
            newGame.secondScore = rand.Next(0, 5);
            while (newGame.firstScore == newGame.secondScore)
            {
                newGame.firstScore = rand.Next(0, 5);
                newGame.secondScore = rand.Next(0, 5);
            }
            return newGame;
        }
        public static void Execute()
        {
            var tree = new BinaryTree();
            string[] teams = { "BEL", "FRA", "BRA", "ENG", "URU", "CRO", "POR", "SPA", "ARG", "COL", "MEX", "SWI", "ITA", "GER", "CHI", "SWE"};
            Game[] games = new Game[teams.Length / 2];
            Random rand = new Random();

            Game emptyGame = new Game();
            emptyGame.firstTeam = String.Empty;
            emptyGame.secondTeam = String.Empty;
            emptyGame.firstScore = 0;
            emptyGame.secondScore = 0;

            BinaryTreeNode[] node = new BinaryTreeNode[15];
            node[0] = tree.AddRoot(emptyGame);
            node[1] = tree.AddLeft(node[0], emptyGame);
            node[2] = tree.AddRight(node[0], emptyGame);

            for (int i = 1, j = 3; i < (node.Length - 1) / 2; i++)
            {
                node[j] = tree.AddLeft(node[i], emptyGame);
                j++;
                node[j] = tree.AddRight(node[i], emptyGame);
                j++;
            }

            for (int i = 0, j = 0; i < games.Length; i++, j += 2)
            {
                Game game = new Game();
                game.firstTeam = teams[j];
                game.secondTeam = teams[j + 1];
                game.firstScore = rand.Next(0, 5);
                game.secondScore = rand.Next(0, 5);
                while (game.firstScore == game.secondScore)
                {
                    game.firstScore = rand.Next(0, 5);
                    game.secondScore = rand.Next(0, 5);
                }

                games[i] = game;
            }

            for (int i = node.Length - 1, j = games.Length - 1; j > -1; i--, j--)
                node[i].data = games[j];

            for (int i = 6; i > -1; i--)
                node[i].data = NextGame(node[i].left.data, node[i].right.data);

            tree.InOrderTraversal();
        }
    }
}
