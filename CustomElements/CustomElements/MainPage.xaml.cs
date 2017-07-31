using CustomElements.Elements;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CustomElements
{
    public partial class MainPage : ContentPage
    {
        public Button openFrame { get; set; }
        public Button openLoading { get; set; }
        public Button openImage { get; set; }
        public Button openButton { get; set; }

        public MainPage()
        {
            InitializeComponent();

            Panel.HeightRequest = App.ScreenHeight;
            Panel.WidthRequest = App.ScreenWidth;

            PanelStack.HeightRequest = App.ScreenHeight;
            PanelStack.WidthRequest = App.ScreenWidth;
            PanelStack.BackgroundColor = Color.Aqua;

            openFrame = new Button();
            openFrame.Text = "Open Frame";
            openFrame.Command = new Command(openFrame_onclick);
            PanelStack.Children.Add(openFrame);

            openImage = new Button();
            openImage.Text = "Open Image";
            openImage.Command = new Command(openImage_onclick);
            PanelStack.Children.Add(openImage);

            openLoading = new Button();
            openLoading.Text = "Open Loading";
            openLoading.Command = new Command(openLoading_onclick);
            PanelStack.Children.Add(openLoading);

            openButton = new Button();
            openButton.Text = "Open Button";
            openButton.Command = new Command(openButton_onclick);
            PanelStack.Children.Add(openButton);

            

        }

        private CustomDialog CreateCustomDialog()
        {
            return new CustomDialog(Panel, Color.FromHex("#80000000"), false);
        }

        private void openButton_onclick(object obj)
        {
            CustomDialog customDialog = CreateCustomDialog();
            Button button = new Button();
            button.Text = "An Example";
            button.Command = new Command(
                    () =>
                    {
                        customDialog.HideAndCleanAlert();
                        customDialog.Destroy();
                    }
                );


            AbsoluteLayout.SetLayoutFlags(button, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(button, new Rectangle(0.5f, 0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            customDialog.ShowAlert(button);

        }

        private void openLoading_onclick(object obj)
        {
            openLoading_onclickAsync(obj);
        }

        private async Task openLoading_onclickAsync(object obj)
        {
            CustomDialog customDialog = CreateCustomDialog();
            ActivityIndicator loading = customDialog.RequireActivityIndicator();

            customDialog.ShowAlert(loading);

            await Task.Delay(5000);

            customDialog.HideAndCleanAlert();
            customDialog.Destroy();
        }

        private void openImage_onclick(object obj)
        {
            CustomDialog customDialog = CreateCustomDialog();
            Image icon = new Image();
            icon.Source = "icon.png";
            icon.HeightRequest = 72;
            icon.WidthRequest = 72;

            AbsoluteLayout.SetLayoutFlags(icon, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(icon, new Rectangle(0.5f, 0.5f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                customDialog.HideAndCleanAlert();
                customDialog.Destroy();
            };
            icon.GestureRecognizers.Add(tapGestureRecognizer);

            customDialog.ShowAlert(icon);
        }

        private void openFrame_onclick(object obj)
        {
            CustomDialog customDialog = CreateCustomDialog();
            Frame frame = customDialog.RequireFramePadrao();

            StackLayout content = new StackLayout();
            content.Margin = new Thickness(3);

            Label label = new Label();
            label.FontSize = 16;
            label.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Integer ac ante mauris.";

            content.Children.Add(label);

            Button positiveButton = new Button()
            {
                BorderColor = Color.Transparent,
                BorderWidth = 0,
                BorderRadius = 0,
                Command = new Command(() => customDialog.HideAndCleanAlert()),
                Text = "Close",
                Margin = new Thickness(0, 0, 10, 0)
            };
            content.Children.Add(positiveButton);

            frame.Content = content;

            customDialog.ShowAlert(frame);

        }
    }
}
