Hey whats up AberFitness.bizzers

Want to know how to install this navbar?

Modify Views/_ViewStart.cshtml and replace:
Layout = "_Layout";
with:
Layout = "_AberFitness_Layout";


Then, in your startup.cs->ConfigureServices make sure you have an HttpClientFactory regisered.
services.AddHttpClient();

That's it.  Peace.