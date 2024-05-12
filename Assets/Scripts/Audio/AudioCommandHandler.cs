public class AudioCommandHandler
{
    public AudioCommandHandler(AudioManager auidoManager)
    {
        m_manager = auidoManager;
    }

    private readonly AudioManager m_manager;

    public void HandleCommand(AudioCommand command)
    {
        command.Handle(m_manager);
    }
}