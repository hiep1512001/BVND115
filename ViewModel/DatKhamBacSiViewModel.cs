
using BVND115.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVND115.ViewModel
{
    public partial class DatKhamBacSiViewModel: ObservableObject
    {
        [ObservableProperty]
        private  ObservableCollection<BacSi> bacSis;
    }
}
