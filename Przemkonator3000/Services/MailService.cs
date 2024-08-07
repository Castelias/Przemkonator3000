using MailKit.Search;
using MailKit;
using Przemkonator3000.Models;
using MailKit.Net.Imap;

namespace Przemkonator3000.Servvices
{
    public class MailService
    {
        public async Task<List<ServerStatus>> FetchServerStatusAsync(Login login, CancellationToken cancellationToken, List<ServerStatus> messageList)
        {

            TextParserService textParserService = new();

            Console.Clear();
            try
            {
                using (var imapClient = new ImapClient())
                {
                    await imapClient.ConnectAsync(Settings.Instance.ImapHost, Settings.Instance.ImapPort, true).ConfigureAwait(false);
                    await imapClient.AuthenticateAsync(login.Username, login.Password).ConfigureAwait(false);

                    var inbox = imapClient.Inbox;
                    await inbox.OpenAsync(FolderAccess.ReadWrite, cancellationToken).ConfigureAwait(false);
                    var uids = await inbox.SearchAsync(SearchQuery.NotSeen, cancellationToken).ConfigureAwait(false);

                    foreach (var uid in uids)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            break;
                        }

                        var message = await inbox.GetMessageAsync(uid, cancellationToken).ConfigureAwait(false);
                        if (textParserService.TryParseSubject(message.Subject, out string serverName, out string statusChange, out string statusBefore, out string statusAfter))
                        {
                            lock (messageList)
                            {
                                messageList.Add(new ServerStatus(serverName, statusChange, statusBefore, statusAfter));
                            }
                            await inbox.AddFlagsAsync(uid, MessageFlags.Seen, true, cancellationToken).ConfigureAwait(false);
                        }
                        else
                        {
                            Console.WriteLine($"Could not parse subject: {message.Subject}");
                        }
                    }
                    await imapClient.DisconnectAsync(true, cancellationToken).ConfigureAwait(false);
                }
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Operation was cancelled.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
            Console.CursorVisible = true;

            return messageList;
        }
    }
}
