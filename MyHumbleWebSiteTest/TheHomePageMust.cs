using Bunit;
using FluentAssertions;
using MyHumbleWebSite.Components;
using MyHumbleWebSite.Pages;
using Xunit;

namespace MyHumbleWebSiteTest
{
    public class TheHomePageMust
    {
        private readonly IRenderedComponent<Index> _cut;

        public TheHomePageMust()
        {
            _cut = new TestContext().RenderComponent<Index>();
        }
        
        [Fact(Skip = "fix jsinterop issue")]
        
        public void ShowAGrid()
        {
            _cut.FindComponent<Grid>().Should().NotBeNull();
        }
    }
}