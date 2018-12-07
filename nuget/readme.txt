Hello AberFitness.bizzers

Want to know how to install this navbar?

Modify Views/Shared/_Layout.cshtml and replace:

<body>
    <nav class="navbar navbar-inverse navbar-fixed-top">
        <!-- whatever content is here -->
    </nav>

    <!-- the rest of the page content.... -->


... with the following:

<body>
    <partial name="AberFitnessLayout/Views/_navbar" />

    <!-- the rest of the page content.... -->




Then, in your startup.cs->ConfigureServices make sure you have an HttpClientFactory regisered.

services.AddHttpClient();