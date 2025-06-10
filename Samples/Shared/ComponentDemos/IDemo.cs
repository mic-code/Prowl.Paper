internal interface IDemo
{
    void DefineStyles();
    void Render();
}

internal interface IDemoThumbnail : IDemo
{
    void RenderThumbnail();
}
