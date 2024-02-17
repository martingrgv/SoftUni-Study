using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public MailBox(int capacity)
        {
            Capacity = capacity;
            (Inbox, Archive) = (new List<Mail>(), new List<Mail>());
        }

        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > 0)
            {
                Inbox.Add(mail);
                Capacity--;
            }    
        }

        public bool DeleteMail(string sender)
        {
            Mail foundMail = Inbox.FirstOrDefault(m => m.Sender == sender);

            if (foundMail != null)
            {
                Inbox.Remove(foundMail);
                Capacity++;
                return true;
            }

            return false;
        }

        public int ArchiveInboxMessages()
        {
            int count = Inbox.Count;
            Capacity = count;

            for (int i = 0; i < Inbox.Count; i++)
            {
                var mail = Inbox[i];

                Archive.Add(mail);
                Inbox.Remove(mail);
                i--;
            }

            return count;
        }

        public string GetLongestMessage() => Inbox.MaxBy(m => m.Body).ToString();

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");

            foreach (var mail in Inbox)
            {
                sb.AppendLine(mail.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
