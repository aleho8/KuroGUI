using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace KuroGUI.Handlers
{
    public class PermHandler
    {
        private List<ulong> BlackListIDs = new List<ulong>();
        private List<ulong> AdminListIDs = new List<ulong>();
        public PermHandler(string BlackListFile, string AdminFile)
        {
            if(File.Exists(BlackListFile))
            {
                string[] Lines = File.ReadAllLines(BlackListFile);  
                foreach(string l in Lines)
                {
                    if (ulong.TryParse(l, out ulong r))
                    {
                        BlackListIDs.Add(r);
                    }
                }
            }
            else
            {
                LogHandler.Log("[PERMLISTHANDLER] Could not find BlackList file! None of the channels is going to be blacklisted.");
            }
            if (File.Exists(AdminFile))
            {
                string[] Lines = File.ReadAllLines(AdminFile);
                foreach (string l in Lines)
                {
                    if (ulong.TryParse(l, out ulong r))
                    {
                        BlackListIDs.Add(r);
                    }
                }
            }
            else
            {
                LogHandler.Log("[PERMLISTHANDLER] Could not find Admin file! There will be no admins.");
            }
        }
        //Blacklist stuff
        public void AddBlackList(ulong ChannelID)
        {
            if (BlackListIDs.IndexOf(ChannelID) == -1)
            {
                BlackListIDs.Add(ChannelID);
            }
            else
            {
                throw new Exception("This Channel is already in the BlackList!");
            }
        }
        public bool BlackListed(ulong ChannelID)
        {
            return BlackListIDs.Contains(ChannelID);
        }
        public void RemoveBlackList(ulong ChannelID)
        {
            if (BlackListIDs.IndexOf(ChannelID) > -1)
            {
                BlackListIDs.Remove(ChannelID);
            }
            else
            {
                throw new Exception("This Channel is not in the BlackList!");
            }
        }
        //Saves lists...
        public async void SaveBlackList()
        {
            try
            {
                File.WriteAllText("blacklist.txt", string.Join("\n", BlackListIDs));
                await LogHandler.Log("[PERMLISTHANDLER] Saved Blacklist File!");
                File.WriteAllText("adminlist.txt", string.Join("\n", AdminListIDs));
                await LogHandler.Log("[PERMLISTHANDLER] Saved Adminlist File!");
            }
            catch { }
        }
        //Admin stuff
        public void AddAdmin(ulong UserID)
        {
            if (AdminListIDs.IndexOf(UserID) == -1)
            {
                AdminListIDs.Add(UserID);
            }
            else
            {
                throw new Exception("This User is already my Admin!");
            }
        }
        public bool IsAdmin(ulong UserID)
        {
            return AdminListIDs.Contains(UserID);
        }
        public void RemoveAdmin(ulong UserID)
        {
            if (AdminListIDs.IndexOf(UserID) > -1)
            {
                AdminListIDs.Remove(UserID);
            }
            else
            {
                throw new Exception("This user is not  my Admin!");
            }
        }
    }
}
