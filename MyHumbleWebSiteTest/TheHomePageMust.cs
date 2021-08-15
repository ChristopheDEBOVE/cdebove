using Bunit;
using christophedebove.Components;
using christophedebove.Pages;
using FluentAssertions;
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