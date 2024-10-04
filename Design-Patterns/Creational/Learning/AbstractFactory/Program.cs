IGUIFactory factory = new WinFactory();
Application app = new Application(factory);
app.Render();

factory = new MacFactory();
app = new Application(factory);
app.Render();