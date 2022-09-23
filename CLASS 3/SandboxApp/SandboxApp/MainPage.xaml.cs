using System.Net.Security;

namespace SandboxApp;

public partial class MainPage : ContentPage
{
	int count = 0;
	Button CounterBtn;


    public MainPage()
	{
		InitializeComponent();

		var image = new Image
		{
			Source = "dotnet_bot.png",
			HeightRequest = 200,
			HorizontalOptions = LayoutOptions.Center
		};
		SemanticProperties.SetDescription(image, "Cute dot net bot waving hi to you!");

		var label = new Label
		{
			Text = "Hello World",
			FontSize = 32,
			HorizontalOptions = LayoutOptions.Center
		};

		var label1 = new Label
		{
			Text = "Welcome to .NET Multi-platform App UI",
			FontSize = 18,
			HorizontalOptions = LayoutOptions.Center
		};

		CounterBtn = new Button
		{
			Text = "Click Me",
			HorizontalOptions = LayoutOptions.Center
		};

        CounterBtn.Clicked += OnCounterClicked;

		Content = new ScrollView
		{
			Content = new VerticalStackLayout
			{	Children = 
				{
					image,
					label,
					label1,
					CounterBtn
				},
				Spacing = 25,
				Padding = new Thickness(30, 0)
			}
		};
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}
}

