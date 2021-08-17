using Bunit;
using FluentAssertions;
using MyHumbleWebSite.Components;
using MyHumbleWebSite.Pages;
using Xunit;

namespace MyHumbleWebSiteTest
{
    public class TheSnakePageMust
    {
        private readonly IRenderedComponent<SnakePage> _cut;

        public TheSnakePageMust()
        {
            _cut = new TestContext().RenderComponent<SnakePage>();
        }
        
        [Fact(Skip = "fix jsinterop issue")]
        
        public void ShowAGrid()
        {
            _cut.FindComponent<Grid>().Should().NotBeNull();
        }
    }
}