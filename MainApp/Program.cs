using Business.Interfaces;
using Business.Services;
using MainApp.Dialogues;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService("contacts.json"));
serviceCollection.AddSingleton<IContactService, ContactService>();
serviceCollection.AddSingleton<MainMenuDialogue>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var MainMenuDialogue = serviceProvider.GetRequiredService<MainMenuDialogue>();

MainMenuDialogue.ShowMainMenu();
