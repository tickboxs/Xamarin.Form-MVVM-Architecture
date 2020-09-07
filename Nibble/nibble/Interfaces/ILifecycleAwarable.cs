using System;
namespace nibble.Interfaces
{
    public interface ILifecycleAwarable
    {
        void ViewDidLoad(); // Called When Page Appeared the first time
        void ViewDidAppear(); // Called When Page Appeared everytime
        void ViewDidDisappear(); // Called When Page disappeared everytime
    }
}
