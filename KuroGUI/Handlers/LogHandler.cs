using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KuroGUI.Handlers
{
    public static class LogHandler
    {
        public static Task Log(string Message, string GuildName = "")
        {
            if (GuildName != "")
            {
                Program.UserInterface.tabControl1.Invoke(new Action(() =>
                {
                    foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                    {
                        if (t.Text.Trim() == GuildName && GuildName != "PRIVATE")
                        {
                            RichTextBox frtb = (RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault();
                            while (frtb.TextLength + Message.Length >= frtb.MaxLength)
                            {
                                frtb.Text = frtb.Text.Substring(frtb.Text.IndexOf("\n") + 1);
                            }
                            frtb.AppendText("\n" + Message);
                        }
                    }
                }));
            }
            Program.UserInterface.ChatOutBox.Invoke(new Action(() =>
            {
                Program.UserInterface.ChatOutBox.AppendText("\n" + Message);
            }));
            return Task.CompletedTask;
        }
        public static Task Clear(string GuildName)
        {
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
                foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                {
                    if (t.Text.Trim() == GuildName && GuildName != "PRIVATE")
                    {
                        ((RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault()).Text = "";
                    }
                }
            }));
            return Task.CompletedTask;
        }
        public static Task LogCache(string Message, string GuildName)
        {
            Program.UserInterface.tabControl1.Invoke(new Action(() =>
            {
                foreach (TabPage t in Program.UserInterface.tabControl1.TabPages)
                {
                    if (t.Text.Trim() == GuildName)
                    {
                        RichTextBox frtb = (RichTextBox)t.Controls.Find("ChatOutBox", false).FirstOrDefault();
                        while (frtb.TextLength + Message.Length >= frtb.MaxLength)
                        {
                            frtb.Text = frtb.Text.Substring(frtb.Text.IndexOf("\n") + 1);
                        }
                        frtb.AppendText("\n" + Message);
                    }
                }
            }));
            return Task.CompletedTask;
        }
    }
}
