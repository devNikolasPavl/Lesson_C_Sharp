﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MatchGame
{
	using System.Windows.Threading;


	public partial class MainWindow : Window
	{
		DispatcherTimer timer = new DispatcherTimer();
		int tenthsOfSecondsElapsed = 0;
		int matchesFound;

		public MainWindow()
		{
			InitializeComponent();

			timer.Interval = TimeSpan.FromSeconds(.1);
			timer.Tick += Timer_Tick;
			SetUpGame();
		}

		private void Timer_Tick(object sender, EventArgs e)
		{
			tenthsOfSecondsElapsed++;
			timeTextBlock.Text = (tenthsOfSecondsElapsed / 10F).ToString("0.0s");
			if (matchesFound == 8)
			{
				timer.Stop();
				timeTextBlock.Text = timeTextBlock.Text + " - Play agayn?";
			}

		}

		private void SetUpGame()
		{
			List<string> animalEmoji = new List<string>()
			{
				"🐙","🐙",
				"🐡","🐡",
				"🐘","🐘",
				"🐳","🐳",
				"🐪","🐪",
				"🦕","🦕",
				"🦘","🦘",
				"🦔","🦔",
			};

			Random random = new Random();

			foreach (TextBlock textBlock in mainGrid.Children.OfType<TextBlock>())
			{
				if (textBlock.Name != "timeTextBlock")
				{
					textBlock.Visibility = Visibility.Visible;
					int index = random.Next(animalEmoji.Count);
					string nextEmoji = animalEmoji[index];
					textBlock.Text = nextEmoji;
					animalEmoji.RemoveAt(index);
				}
			}

			timer.Start();
			tenthsOfSecondsElapsed = 0;
			matchesFound = 0;
		}

		/* Если щелчок сделан на первом животном в паре, сохранить информацию
		 * о том, на каком элементе TextBlock щелкнул пользователь, и убрать
		 * животное с экрана. Если это второе животное в паре, либо убрать
		 * его с экрана (если животное составляют пару), либо вернуть на экран
		 * первое животное (если животное разное).
		 */

		TextBlock lastTextBlockClicked;
		bool findingMatch = false;

		private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			TextBlock textBlock = sender as TextBlock;
			if (findingMatch == false)
			{
				textBlock.Visibility = Visibility.Hidden;
				lastTextBlockClicked = textBlock;
				findingMatch = true;
			}
			else if (textBlock.Text == lastTextBlockClicked.Text)
			{
				matchesFound++;
				textBlock.Visibility = Visibility.Hidden;
				findingMatch = false;
			}
			else
			{
				lastTextBlockClicked.Visibility = Visibility.Visible;
				findingMatch = false;
			}
		}

		/* Сбрасываем игру, если были найдены все 8 пар (в противном случае
		 * ничего не делать, потому что игра еще продолжается).
		 */
		private void TimeTextBlock_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (matchesFound == 8)
			{
				SetUpGame();
			}
		}
	}
}