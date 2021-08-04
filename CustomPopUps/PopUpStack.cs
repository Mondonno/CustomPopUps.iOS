using System;
using System.Collections.Generic;

namespace CustomPopUps
{
    public class PopUpStack
    {
        public List<PopUp> PopUps { get; private set; } = new List<PopUp>();

        public void Add(PopUp pop)
            => PopUps.Add(pop);

        public void Show(PopUp popUp)
        {
            Add(popUp);
            Show(PopUps.Count - 1);
        }

        public void Show(int index)
        {
            Hide(index - 1);
            PopUps[index].Show();
        }

        public void Remove(int index)
        {
            Hide(index);
            PopUps.RemoveAt(index);
            if (index - 1 >= 0) Show(index - 1);
        }

        public void Hide(int index)
            => PopUps[index].Close();
    }
}
