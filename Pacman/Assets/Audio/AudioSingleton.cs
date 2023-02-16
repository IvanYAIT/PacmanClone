public class AudioSingleton
{
    public float music = 0;
    public float sfx = 0;
    private static AudioSingleton instance;

    private AudioSingleton() { }

    public static AudioSingleton getInstance()
    {
        if (instance == null)
            instance = new AudioSingleton();
        return instance;
    }
}