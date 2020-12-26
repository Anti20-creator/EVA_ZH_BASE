using System;
using System.Collections.Generic;
using System.Text;

namespace ZH
{
    public class Model
    {
        int size;
        public int Size { get { return size; } set { size = value; } }
        public EventHandler<int> generateTable;
        public Model() {
            Size = 0;
        }

        public void StartGame(int e)
        {
            OnGenerateTable(e);
            Size = e;
        }

        private void OnGenerateTable(int e)
        {
            if (generateTable != null)
            {
                generateTable(this, e);
            }
        }
    }
}
