namespace mauiDragDropBug;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

    void OnDragStarting(object sender, DragStartingEventArgs e)
    {
        Image image = (sender as Element).Parent as Image;
        if (image != null)
            e.Data.Image = image.Source;        
    }

    async void OnDrop(object sender, DropEventArgs e)
    {
        var imgSource = await e.Data.GetImageAsync();
        if (!ImageSource.IsNullOrEmpty(imgSource))
        {
            Image image = (sender as Element).Parent as Image;
            if (image != null)
                image.Source = imgSource;
        }
    }
}

