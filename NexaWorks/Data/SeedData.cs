using Microsoft.EntityFrameworkCore;
using NexaWorks.Models;
using System.Net.Sockets;

namespace NexaWorks.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

            if (context.Products.Any() && context.Versions.Any() && context.OSs.Any() && context.Tickets.Any() && context.Targets.Any())
            {
                return;
            }/**/

            Product ProdHerbe = new Product
            { Name = "Trader en Herbe" };
            Product ProdInves = new Product
            { Name = "Maitre des investissements" };
            Product ProdEntrain = new Product
            { Name = "Planificateur d'Entraînement" };
            Product ProdSocial = new Product
            { Name = "Planificateur d'Anxiété Sociale" };
            context.Products.AddRange(
                ProdHerbe, ProdInves, ProdEntrain, ProdSocial);
            context.SaveChanges();

            #region Versions
            NexaWorks.Models.Version Vers10Herbe = new NexaWorks.Models.Version
            { NumVersion = "1.0", ProductKeyId = ProdHerbe.Id };
            NexaWorks.Models.Version Vers11Herbe = new NexaWorks.Models.Version
            { NumVersion = "1.1", ProductKeyId = ProdHerbe.Id };
            NexaWorks.Models.Version Vers12Herbe = new NexaWorks.Models.Version
            { NumVersion = "1.2", ProductKeyId = ProdHerbe.Id };
            NexaWorks.Models.Version Vers13Herbe = new NexaWorks.Models.Version
            { NumVersion = "1.3", ProductKeyId = ProdHerbe.Id };
            NexaWorks.Models.Version Vers10Inves = new NexaWorks.Models.Version
            { NumVersion = "1.0", ProductKeyId = ProdInves.Id };
            NexaWorks.Models.Version Vers20Inves = new NexaWorks.Models.Version
            { NumVersion = "2.0", ProductKeyId = ProdInves.Id };
            NexaWorks.Models.Version Vers21Inves = new NexaWorks.Models.Version
            { NumVersion = "2.1", ProductKeyId = ProdInves.Id };
            NexaWorks.Models.Version Vers10Entrain = new NexaWorks.Models.Version
            { NumVersion = "1.0", ProductKeyId = ProdEntrain.Id };
            NexaWorks.Models.Version Vers11Entrain = new NexaWorks.Models.Version
            { NumVersion = "1.1", ProductKeyId = ProdEntrain.Id };
            NexaWorks.Models.Version Vers20Entrain = new NexaWorks.Models.Version
            { NumVersion = "2.0", ProductKeyId = ProdEntrain.Id };
            NexaWorks.Models.Version Vers10Social = new NexaWorks.Models.Version
            { NumVersion = "1.0", ProductKeyId = ProdSocial.Id };
            NexaWorks.Models.Version Vers11Social = new NexaWorks.Models.Version
            { NumVersion = "1.1", ProductKeyId = ProdSocial.Id };
            context.Versions.AddRange(
                Vers10Herbe,
                Vers11Herbe,
                Vers12Herbe,
                Vers13Herbe,
                Vers10Inves,
                Vers20Inves,
                Vers21Inves,
                Vers10Entrain,
                Vers11Entrain,
                Vers20Entrain,
                Vers10Social,
                Vers11Social);
            context.SaveChanges();
            #endregion

            OS OSLinux = new OS{ Name = "Linux" };
            OS OSMacOS = new OS { Name = "MacOS" };
            OS OSWindows = new OS { Name = "Windows" };
            OS OSAndroid = new OS { Name = "Android" };
            OS OSiOS = new OS { Name = "iOS" };
            OS OSWinMobile = new OS { Name = "Windows Mobile" };
            context.OSs.AddRange(
                OSLinux, OSMacOS, OSWindows, OSAndroid, OSiOS, OSWinMobile);
            context.SaveChanges();

            #region Target Version_OS
            Version_OS TargetHerbe10Linux = new Version_OS
            {
                VersionKeyId = Vers10Herbe.Id,
                OSKeyId = OSLinux.Id
            };
            Version_OS TargetHerbe10Windows = new Version_OS
            {
                VersionKeyId = Vers10Herbe.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetHerbe11Linux = new Version_OS
            {
                VersionKeyId = Vers11Herbe.Id,
                OSKeyId = OSLinux.Id
            };
            Version_OS TargetHerbe11MacOS = new Version_OS
            {
                VersionKeyId = Vers11Herbe.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetHerbe11Windows = new Version_OS
            {
                VersionKeyId = Vers11Herbe.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetHerbe12Linux = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSLinux.Id
            };
            Version_OS TargetHerbe12MacOS = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetHerbe12Windows = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetHerbe12Android = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetHerbe12iOS = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSiOS.Id
            };
            Version_OS TargetHerbe12WinMobile = new Version_OS
            {
                VersionKeyId = Vers12Herbe.Id,
                OSKeyId = OSWinMobile.Id
            };
            Version_OS TargetHerbe13MacOS = new Version_OS
            {
                VersionKeyId = Vers13Herbe.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetHerbe13Windows = new Version_OS
            {
                VersionKeyId = Vers13Herbe.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetHerbe13Android = new Version_OS
            {
                VersionKeyId = Vers13Herbe.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetHerbe13iOS = new Version_OS
            {
                VersionKeyId = Vers13Herbe.Id,
                OSKeyId = OSiOS.Id
            };

            Version_OS TargetInves10MacOS = new Version_OS
            {
                VersionKeyId = Vers10Inves.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetInves10iOS = new Version_OS
            {
                VersionKeyId = Vers10Inves.Id,
                OSKeyId = OSiOS.Id
            };
            Version_OS TargetInves20MacOS = new Version_OS
            {
                VersionKeyId = Vers20Inves.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetInves20Android = new Version_OS
            {
                VersionKeyId = Vers20Inves.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetInves20iOS = new Version_OS
            {
                VersionKeyId = Vers20Inves.Id,
                OSKeyId = OSiOS.Id
            };
            Version_OS TargetInves21MacOS = new Version_OS
            {
                VersionKeyId = Vers21Inves.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetInves21Windows = new Version_OS
            {
                VersionKeyId = Vers21Inves.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetInves21Android = new Version_OS
            {
                VersionKeyId = Vers21Inves.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetInves21iOS = new Version_OS
            {
                VersionKeyId = Vers21Inves.Id,
                OSKeyId = OSiOS.Id
            };

            Version_OS TargetEntrain10Linux = new Version_OS
            {
                VersionKeyId = Vers10Entrain.Id,
                OSKeyId = OSLinux.Id
            };
            Version_OS TargetEntrain10MacOS = new Version_OS
            {
                VersionKeyId = Vers10Entrain.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetEntrain11Linux = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSLinux.Id
            };
            Version_OS TargetEntrain11MacOS = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetEntrain11Windows = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetEntrain11Android = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetEntrain11iOS = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSiOS.Id
            };
            Version_OS TargetEntrain11WinMobile = new Version_OS
            {
                VersionKeyId = Vers11Entrain.Id,
                OSKeyId = OSWinMobile.Id
            };
            Version_OS TargetEntrain20MacOS = new Version_OS
            {
                VersionKeyId = Vers20Entrain.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetEntrain20Windows = new Version_OS
            {
                VersionKeyId = Vers20Entrain.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetEntrain20Android = new Version_OS
            {
                VersionKeyId = Vers20Entrain.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetEntrain20iOS = new Version_OS
            {
                VersionKeyId = Vers20Entrain.Id,
                OSKeyId = OSiOS.Id
            };

            Version_OS TargetSocial10MacOS = new Version_OS
            {
                VersionKeyId = Vers10Social.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetSocial10Windows = new Version_OS
            {
                VersionKeyId = Vers10Social.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetSocial10Android = new Version_OS
            {
                VersionKeyId = Vers10Social.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetSocial10iOS = new Version_OS
            {
                VersionKeyId = Vers10Social.Id,
                OSKeyId = OSiOS.Id
            };
            Version_OS TargetSocial11MacOS = new Version_OS
            {
                VersionKeyId = Vers11Social.Id,
                OSKeyId = OSMacOS.Id
            };
            Version_OS TargetSocial11Windows = new Version_OS
            {
                VersionKeyId = Vers11Social.Id,
                OSKeyId = OSWindows.Id
            };
            Version_OS TargetSocial11Android = new Version_OS
            {
                VersionKeyId = Vers11Social.Id,
                OSKeyId = OSAndroid.Id
            };
            Version_OS TargetSocial11iOS = new Version_OS
            {
                VersionKeyId = Vers11Social.Id,
                OSKeyId = OSiOS.Id
            };
            context.AddRange(
                TargetHerbe10Linux,
                TargetHerbe10Windows,
                TargetHerbe11Linux,
                TargetHerbe11MacOS,
                TargetHerbe11Windows,
                TargetHerbe12Linux,
                TargetHerbe12MacOS,
                TargetHerbe12Windows,
                TargetHerbe12Android,
                TargetHerbe12iOS,
                TargetHerbe12WinMobile,
                TargetHerbe13MacOS,
                TargetHerbe13Windows,
                TargetHerbe13Android,
                TargetHerbe13iOS,

                TargetInves10MacOS,
                TargetInves10iOS,
                TargetInves20MacOS,
                TargetInves20Android,
                TargetInves20iOS,
                TargetInves21MacOS,
                TargetInves21Windows,
                TargetInves21Android,
                TargetInves21iOS,

                TargetEntrain10Linux,
                TargetEntrain10MacOS,
                TargetEntrain11Linux,
                TargetEntrain11MacOS,
                TargetEntrain11Windows,
                TargetEntrain11Android,
                TargetEntrain11iOS,
                TargetEntrain11WinMobile,
                TargetEntrain20MacOS,
                TargetEntrain20Windows,
                TargetEntrain20Android,
                TargetEntrain20iOS,

                TargetSocial10MacOS,
                TargetSocial10Windows,
                TargetSocial10Android,
                TargetSocial10iOS,
                TargetSocial11MacOS,
                TargetSocial11Windows,
                TargetSocial11Android,
                TargetSocial11iOS
                );
            context.SaveChanges();
            #endregion

            #region Tickets
            Ticket ticketTest = new Ticket
            {
                DateCreat = new DateOnly(2023, 03, 2),
                DateResolve = new DateOnly(2023,4,16),
                IsResolved = true,
                Description = "L’utilisateur dit que les achats se font en double pour chaque achat effectué. Si l’utilisateur souhaite acheter 10 actions Apple, le programme effectue deux transactions, chacune pour 10 actions.",
                ResolveDescription = "L’utilisateur était sur un réseau 3G et s’attendait à ce que l’achat soit effectué plus rapidement qu’il ne l’a été. L’utilisateur a cliqué sur le bouton d’achat. Comme l’écran n’a pas changé assez rapidement, il a cliqué à nouveau. Envoi d’une demande à l’équipe de développement pour ajouter une animation « en cours » lorsque des achats sont effectués et désactiver le bouton d’achat après le premier clic.",
                AssociatedVersionOSId = TargetHerbe12iOS.Id
            };
            Ticket ticket1 = new Ticket
            {
                DateCreat = new DateOnly(2022, 10, 8),
                DateResolve = new DateOnly(2022, 10, 27),
                IsResolved = true,
                Description = "L'utilisateur dit que l'application dois faire une mise à jour quand elle est lancée, mais aucun telechargement ne se lance quand il essaye de faire la mise à jour.",
                ResolveDescription = "L'utilisateur a essayer de lancer l'application alors qu'il était en déplacement et n'avais aucune connexion internet.",
                AssociatedVersionOSId = TargetSocial10Android.Id
            };
            Ticket ticket2 = new Ticket
            {
                DateCreat = new DateOnly(2023, 5, 12),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur rapportent qu'après avoir exporté ses données sous format CSV, les colonnes sont désorganisées, ce qui rend les données illisibles.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetInves21Windows.Id
            };
            Ticket ticket3 = new Ticket
            {
                DateCreat = new DateOnly(2023, 1, 20),
                DateResolve = new DateOnly(2023, 2, 15),
                IsResolved = true,
                Description = "L'utilisateur signale que l'application plante dès qu'un programme d'entrainement contenant plus de 10 exercices est planifié.",
                ResolveDescription = "Une surchage de mémoire causait les plantages sur les appareils anciens. Une mise à jour a été déployée pour optimiser l'utilisation des ressources.",
                AssociatedVersionOSId = TargetEntrain11iOS.Id
            };
            Ticket ticket4 = new Ticket
            {
                DateCreat = new DateOnly(2023, 11, 10),
                DateResolve = null,
                IsResolved = false,
                Description = "L'application reste figée lorsque l'utilisateur essaie d'ajouter plus de trois événements en un seul clic via l'option \"Ajouter multiples événements\".",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial11MacOS.Id
            };
            Ticket ticket5 = new Ticket
            {
                DateCreat = new DateOnly(2022, 7, 3),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur reçoie des notifications incorrectes indiquant des changement de la valeur des actions éroné.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetInves20Android.Id
            };
            Ticket ticket6 = new Ticket
            {
                DateCreat = new DateOnly(2023, 6, 13),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur indique que certains événements ne sont pas enregistrés lors d'un ajout de plus de 5 événements d'un coup via l'option \"Ajouter multiples événements\".",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial10Windows.Id
            };
            Ticket ticket7 = new Ticket
            {
                DateCreat = new DateOnly(2022, 2, 24),
                DateResolve = new DateOnly(2022, 3, 3),
                IsResolved = true,
                Description = "L'utilisateur rapporte que son programme d'entrainement enregistré a disparu après une mise à jour de l'application.",
                ResolveDescription = "L'utilisateur avait réinitialisé le disque dur de son ordinateur quelques jours avant, les données de l'application ont été perdues dans le processus.",
                AssociatedVersionOSId = TargetEntrain10Linux.Id
            };
            Ticket ticket8 = new Ticket
            {
                DateCreat = new DateOnly(2022, 8, 5),
                DateResolve = null,
                IsResolved = false,
                Description = "Lors de l'activation des notifications de rappel, certains rappels ne se déclenchent pas à l'heure programmée.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetEntrain10Linux.Id
            };
            Ticket ticket9 = new Ticket
            {
                DateCreat = new DateOnly(2023, 2, 22),
                DateResolve = new DateOnly(2023, 3, 12),
                IsResolved = true,
                Description = "L'application plante lors de l'ajout d'un portefeuille de plus de 50 actifs financiers.",
                ResolveDescription = "Un correctif a été déployé pour optimiser la gestion des portefeuilles contenant un grand nombre d'éléments. L'utilisateur est invité à faire la mise à jour vers la version 2.0.",
                AssociatedVersionOSId = TargetInves10iOS.Id
            };
            Ticket ticket10 = new Ticket
            {
                DateCreat = new DateOnly(2023, 9, 14),
                DateResolve = null,
                IsResolved = false,
                Description = "Lorsqu'un utilisateur modifie un exercice existant, le programme entraîne automatiquement un dédoublement des exercices dans le calendrier.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetEntrain11MacOS.Id
            };
            Ticket ticket11 = new Ticket
            {
                DateCreat = new DateOnly(2023, 4, 3),
                DateResolve = new DateOnly(2023, 4, 20),
                IsResolved = true,
                Description = "Les montants affichés dans l'aperçu des transactions ne sont pas correctement arrondis et présentent des erreurs de calcul mineures.",
                ResolveDescription = "Amélioration de la précision du calcul des montants et correctif déployé dans la version 1.1.",
                AssociatedVersionOSId = TargetHerbe10Windows.Id
            };
            Ticket ticket12 = new Ticket
            {
                DateCreat = new DateOnly(2023, 8, 11),
                DateResolve = null,
                IsResolved = false,
                Description = "Les objectifs définis par les utilisateurs dans l'application ne sont pas sauvegardés correctement après la déconnexion de l'application.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetEntrain20Android.Id
            };
            Ticket ticket13 = new Ticket
            {
                DateCreat = new DateOnly(2023, 3, 15),
                DateResolve = new DateOnly(2023, 4, 2),
                IsResolved = true,
                Description = "L'utilisateur rapporte des problèmes d'affichage lorsque l'application est utilisée sur un écran externe de résolution 4K.",
                ResolveDescription = "Adaptation de l'interface pour une meilleure prise en charge des écrans haute résolution.",
                AssociatedVersionOSId = TargetInves20MacOS.Id
            };
            Ticket ticket14 = new Ticket
            {
                DateCreat = new DateOnly(2023, 10, 9),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur constate des écarts d'une heure dans les heures programmées pour les rappels lors du passage à l'heure d'hiver.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial11Android.Id
            };
            Ticket ticket15 = new Ticket
            {
                DateCreat = new DateOnly(2023, 5, 18),
                DateResolve = new DateOnly(2023, 5, 25),
                IsResolved = true,
                Description = "L'application affiche un message d'erreur générique lorsque l'utilisateur tente d'ajouter un compte bancaire non valide.",
                ResolveDescription = "Mise à jour de la logique de validation des comptes et ajout d'un message d'erreur plus explicite.",
                AssociatedVersionOSId = TargetHerbe11Linux.Id
            };
            Ticket ticket16 = new Ticket
            {
                DateCreat = new DateOnly(2023, 7, 10),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur indique que les couleurs du mode sombre ne sont pas correctement appliquées, rendant le texte illisible dans certaines sections.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial11iOS.Id
            };
            Ticket ticket17 = new Ticket
            {
                DateCreat = new DateOnly(2023, 9, 8),
                DateResolve = new DateOnly(2023, 9, 15),
                IsResolved = true,
                Description = "Les données de certains actifs ne se mettent pas à jour en temps réel lorsque l'utilisateur est en 4G.",
                ResolveDescription = "Une mise à jour a été déployée pour optimiser les connexions réseau et améliorer la synchronisation des données.",
                AssociatedVersionOSId = TargetInves20Android.Id
            };
            Ticket ticket18 = new Ticket
            {
                DateCreat = new DateOnly(2023, 8, 2),
                DateResolve = null,
                IsResolved = false,
                Description = "Lors de l'importation d'un fichier d'exercices personnalisé, l'application se ferme brusquement sans message d'erreur.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetEntrain11WinMobile.Id
            };
            Ticket ticket19 = new Ticket
            {
                DateCreat = new DateOnly(2023, 5, 12),
                DateResolve = new DateOnly(2023, 5, 26),
                IsResolved = true,
                Description = "Certains utilisateurs signalent que leurs portefeuilles apparaissent vides lorsqu'ils se reconnectent après une mise à jour.",
                ResolveDescription = "Correction d'un bug lié à la synchronisation des comptes après la mise à jour.",
                AssociatedVersionOSId = TargetHerbe12WinMobile.Id
            };
            Ticket ticket20 = new Ticket
            {
                DateCreat = new DateOnly(2023, 1, 7),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur ne peut pas accéder au menu \"Ajouter des notes\" lorsque l'application est ouverte en plein écran.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial11Windows.Id
            };
            Ticket ticket21 = new Ticket
            {
                DateCreat = new DateOnly(2023, 3, 28),
                DateResolve = null,
                IsResolved = false,
                Description = "Les historiques des transactions de certains portefeuilles ne s'affichent pas dans l'onglet dédié.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetInves21Windows.Id
            };
            Ticket ticket22 = new Ticket
            {
                DateCreat = new DateOnly(2023, 6, 19),
                DateResolve = new DateOnly(2023, 6, 27),
                IsResolved = true,
                Description = "L'application envoie des notifications pour des exercices déjà réalisés, perturbant le suivi de l'utilisateur.",
                ResolveDescription = "Correctif ajouté pour vérifier l'état de complétion avant d'envoyer des rappels.",
                AssociatedVersionOSId = TargetEntrain20Android.Id
            };
            Ticket ticket23 = new Ticket
            {
                DateCreat = new DateOnly(2023, 3, 5),
                DateResolve = null,
                IsResolved = false,
                Description = "L'utilisateur ne reçoit pas de notification après avoir placé un ordre d'achat ou de vente.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetHerbe13Android.Id
            };
            Ticket ticket24 = new Ticket
            {
                DateCreat = new DateOnly(2023, 8, 12),
                DateResolve = null,
                IsResolved = false,
                Description = "Lorsque l'utilisateur tente de synchroniser ses événements avec son calendrier Google, certains événements ne sont pas importés correctement.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetSocial10Android.Id
            };
            Ticket ticket25 = new Ticket
            {
                DateCreat = new DateOnly(2023, 10, 28),
                DateResolve = null,
                IsResolved = false,
                Description = "L'application ne met pas à jour les taux de change en temps réel, bien que la fonctionnalité soit activée.",
                ResolveDescription = null,
                AssociatedVersionOSId = TargetHerbe12WinMobile.Id
            };
            context.AddRange(
                ticketTest,ticket1, ticket2, ticket3, ticket4, ticket5,ticket6, ticket7, ticket8, ticket9,
                ticket10, ticket11, ticket12, ticket13, ticket14, ticket15, ticket16, ticket17, ticket18, ticket19,
                ticket20, ticket21, ticket22, ticket23, ticket24, ticket25);
            context.SaveChanges();
            #endregion
        }

    }
}
