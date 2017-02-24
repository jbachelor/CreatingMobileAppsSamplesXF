using System;
using Prism.Events;

namespace CreatingMobileAppsSamples.Services
{
	public class PageAppearingEvent : PubSubEvent<string> { }
	public class PageDisappearingEvent : PubSubEvent<string> { }
}
