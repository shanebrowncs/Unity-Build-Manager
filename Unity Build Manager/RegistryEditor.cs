using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

class RegistryEditor
{
    public object ReadFromRegistry(string Name, string Path, bool localMachine, object DefaultReturn)
    {
        RegistryKey key;
        if (localMachine)
        {
            key = Registry.LocalMachine.OpenSubKey(Path);
        }
        else
        {
            key = Registry.CurrentUser.OpenSubKey(Path);
        }

        if (key == null)
            return DefaultReturn;

        return key.GetValue(Name, DefaultReturn);
    }

    public void WriteToRegistry(string Name, string Path, object value)
    {
        RegistryKey Key = Registry.CurrentUser.CreateSubKey(Path);

        if (Key == null)
            return;

        Key.SetValue(Name, value);
        Key.Close();
    }
}
