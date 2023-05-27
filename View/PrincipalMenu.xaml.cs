using JPA_Porra_Burgos.restclient;
using JPA_Porra_Burgos.restclient.request.Errors;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using RestClientBCF;
using RestClientBCF.restclient.constants;
using RestClientBCF.restclient.request;
using RestClientBCF.restclient.request.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace JPA_Porra_Burgos.View
{
    /// <summary>
    /// 
    /// Clase vinculada a la Ventana principal de la aplicación. Contiene todos los eventos de ésta, divididos por paneles para diferenciarlos 
    /// fácilmente.
    ///  
    /// De inicio tenemos cargados todos los Repositorios-DAO que vamos a usar para comunicarnos con la BD.
    ///  
    /// </summary> 
    public partial class PrincipalMenu : Window
    {
        static RulesRestClientService rulesRestClientService = new RulesRestClientService();
        static TeamRestClientService teamRestClienService = new TeamRestClientService();
        static SeasonRestClientService seasonRestClientService = new SeasonRestClientService();
        static PlayerRestClientService playerRestClientService = new PlayerRestClientService();
        static ConcreteMatchRestClientService concreteMatchRestClientService = new ConcreteMatchRestClientService();
        static FootballDayRestClientService footballDayRestClientService = new FootballDayRestClientService();
        static SendLogsRestClientService sendLogsRestClientService = new SendLogsRestClientService();
        static DownloadLicenseRestClientService downloadLicenseRestClientService = new DownloadLicenseRestClientService();

        private const string EMPTY_STR = "";

        public PrincipalMenu() => InitMenu();

        private void InitMenu()
        {
            InitializeComponent();
            AllowDrag();
        }

        // Eventos ventana principal: Eventos comunes en toda la Ventana.

        /// <summary>
        /// 
        /// Evento que permite realizar drag and drop con la ventana.
        /// 
        /// </summary>
        private void AllowDrag()
        {
            MouseLeftButtonDown += (s, e) =>
                DragMove();
        }

        /// <summary>
        /// 
        /// Evento para cerrar la ventana. Se pregunta al usuario si realmente quiere hacerlo.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnClickClose(object sender, RoutedEventArgs e)
        {
            ringActive();
            var questDialog = AppQuestDialog.Show("¿Seguro que quieres salir?");
            var result = await CloseApp(questDialog);
            if (result)
            {
                Close();
            }
            ringDisabled();
        }

        private async Task<bool> CloseApp(AppQuestDialog questDialog)
        {
            return await Task.Run(() =>
              {
                  return questDialog.Result;
              });

        }

        /// <summary>
        /// 
        /// Evento para abrir el panel de ayuda u ocultarlo si está abierto.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickHelp(object sender, RoutedEventArgs e)
        {
            card.Visibility = card.Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
        }


        //Eventos de diseño: Eventos de diseño, simplemente son eventos para efectos visuales de los botones de la aplicación.

        /// <summary>
        /// 
        /// Evento para cambiar el foreground cuando el ratón entra en el botón.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnterFGChange(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Foreground = Brushes.Black;
        }

        /// <summary>
        /// 
        /// Evento para cambiar el foreground cuando el ratón sale del botón.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnLeaveFGChange(object sender, System.Windows.Input.MouseEventArgs e)
        {
            var btn = sender as Button;
            btn.Foreground = Brushes.WhiteSmoke;
        }



        // Eventos de navegación entre componentes: Eventos comunes a todos los paneles de navegación.
        // Tal como se ha diseñado, los paneles son cartas, y los eventos que se preocupan de gestionar
        //la visibilidad u ocultamiento de estos son los que encontramos aquí.


        /// <summary>
        /// 
        /// Evento para volver atrás, oculta el panel activo y muestra al que se debe dirigir.
        /// Para entender su funcionamiento ver los siguientes métodos.
        /// 
        /// <see cref="GetSignal(object)"/>
        /// <see cref="ChangeVisibility(char, Visibility)"/>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickBack(object sender, RoutedEventArgs e)
        {
            char signal = GetSignal(sender);
            ChangeVisibility(signal, Visibility.Hidden);
        }

        /// <summary>
        /// 
        /// Evento para navegar adelante, oculta el panel activo y muestra al que se debe dirigir.
        /// Para entender su funcionamiento ver los siguientes métodos.
        /// 
        /// <see cref="GetSignal(object)"/>
        /// <see cref="ChangeVisibility(char, Visibility)"/>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnClickShow(object sender, RoutedEventArgs e)
        {
            char signal = GetSignal(sender);
            ChangeVisibility(signal, Visibility.Visible);
        }

        /// <summary>
        /// 
        /// Este método recibe el sender, recoge una señal en el nombre de este y la retorna.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        private static char GetSignal(object sender)
        {
            var btn = sender as Button;
            var signal = btn.Name[btn.Name.Length - 1];
            return signal;
        }

        /// <summary>
        /// 
        /// Este método se encarga de gestionar la visibilidad de los paneles (cartas), según la señal y el valor de visibilidad
        /// hace una cosa u otra, mediante un switch conoce que panel debe manipular.
        /// 
        /// </summary>
        /// <param name="signal"></param>
        /// <param name="visibility"></param>
        private void ChangeVisibility(char signal, Visibility visibility)
        {
            switch (signal)
            {
                case 'e':
                    cardTeams.Visibility = visibility;
                    break;
                case 'j':
                    cardJourney.Visibility = visibility;
                    break;
                case 'p':
                    cardPlayers.Visibility = visibility;
                    break;
                case 't':
                    cardResults.Visibility = visibility;
                    break;
                case 'r':
                    cardRules.Visibility = visibility;
                    break;
                case 'i':
                    cardInitJourney.Visibility = visibility;
                    break;
                case 'a':
                    cardActualJourney.Visibility = visibility;
                    break;
                case 'c':
                    cardAdjust.Visibility = visibility;
                    break;
                case 's':
                    cardSupport.Visibility = visibility;
                    break;

            }
        }


        //Eventos  REGEX : Eventos que usan expresiones regulares para restringir los input introducidos.


        private void OnTxtChanged_ForDigitOnly(object sender, TextCompositionEventArgs e)
        {
            var txtBox = sender as TextBox;
            e.Handled = txtBox.Text.Length < 2 ? Handled(e) : true;
        }

        private bool Handled(TextCompositionEventArgs e)
        {
            return !System.Text.RegularExpressions.Regex.IsMatch(e.Text, "^[0-9]"); ;
        }

        private void OnSpacePress_NoEvent(object sender, KeyEventArgs e)
        {
            e.Handled = e.Key == Key.Space;
        }

        //
        //  A PARTIR DE AQUÍ EMPIEZAN LOS EVENTOS DE LOS PANELES IMPORTANTES DE LA APP.
        //

        // Eventos Ajustes : panel AJUSTES
        private void OnClickOpenRules(object sender, RoutedEventArgs e)
        {
            cardAdjust.Visibility = Visibility.Hidden;
            OnClickShow(sender, e);
        }

        private void OnClickOpenSupport(object sender, RoutedEventArgs e)
        {
            cardAdjust.Visibility = Visibility.Hidden;
            OnClickShow(sender, e);
        }

        // Eventos Datos::rulescard : Los eventos relacionados con el panel de REGLAS.

        private async void OnVisibility_Visible(object sender, DependencyPropertyChangedEventArgs e)
        {
            var card = sender as Card;
            if (card.Visibility == Visibility.Visible)
            {
                await TryToShowRulesSetAsync(true);
            }
        }

        static string fileName;

        private void OnEnterLoadFile(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.ShowReadOnly = true;
            openFileDialog.ShowDialog();
            fileName = openFileDialog.SafeFileName;
            txtPdfPath.Text = openFileDialog.FileName;
        }

        private async void OnClick_DefaultValues(object sender, RoutedEventArgs e)
        {
            ringActive();
            var fileUri = txtPdfPath.Text;
            if (String.IsNullOrEmpty(fileUri))
            {

                AppWarnDialog.Show("Debe seleccionarse un fichero .pdf a enviar.\nEl PDF con el contenido de las reglas de participación y puntuación.");

            }
            else
            {
                await TryToUpdateRulesAndShowAsync(null, fileUri, fileName);
            }
            ringDisabled();
        }

        private async void OnClick_UpdateRules(object sender, RoutedEventArgs e)
        {
            ringActive();
            var fileUri = txtPdfPath.Text;
            if (String.IsNullOrEmpty(fileUri))
            {
                AppMessageDialog.Show("Debe seleccionarse un fichero .pdf a enviar, con el contenido de las reglas de participación y puntuación.");

            }
            else
            {
                var rules = new Rules();
                var textPR = txtPR.Text;
                var textSR = txtSR.Text;
                var textGR = txtGR.Text;
                var prValid = validatePoints(textPR);
                var srValid = validatePoints(textSR);
                var grValid = validatePoints(textGR);
                if (!prValid || !srValid || !grValid)
                {
                    AppMessageDialog.Show("Se deben introducir valores en los 3 campos para poder actualizar las reglas.");
                }
                else
                {
                    rules.resultPoints = int.Parse(textPR);
                    rules.signPoints = int.Parse(txtSR.Text);
                    rules.goalsBCFPoints = int.Parse(txtGR.Text);
                    await TryToUpdateRulesAndShowAsync(rules, fileUri, fileName);
                }
            }
            ringDisabled();

        }

        private bool validatePoints(string txt)
        {
            return !String.IsNullOrWhiteSpace(txt);
        }

        private void Back_R_ToInitial(object sender, RoutedEventArgs e)
        {
            txtPdfPath.Text = null;
            txtPR.Text = null;
            txtSR.Text = null;
            txtGR.Text = null;
            fileName = null;
            cardRules.Visibility = Visibility.Hidden;
            cardAdjust.Visibility = Visibility.Visible;
        }

        private async Task TryToShowRulesSetAsync(bool notUpdate)
        {
            try
            {
                ringActive();
                var rulesResponse = await rulesRestClientService.getRules();
                await TryToManipulateRulesWrapperAsync(rulesResponse, notUpdate);
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }
        private async Task TryToUpdateRulesAndShowAsync(Rules rules, string fileUri, string fileName)
        {
            try
            {
                DisabledAllInRulesPanel(true);
                var rulesResponse = await rulesRestClientService.setRules(rules, fileUri, fileName);
                await TryToManipulateRulesWrapperAsync(rulesResponse, false);
            }
            catch (Exception ex)
            {
                DisabledAllInRulesPanel(false);
                AppWarnDialog.Show(ex.Message);
            }
        }

        private void DisabledAllInRulesPanel(bool disabled)
        {
            txtPR.IsEnabled = !disabled;
            txtSR.IsEnabled = !disabled;
            txtGR.IsEnabled = !disabled;
            btnLoadPdf.IsEnabled = !disabled;
            btnDftR.IsEnabled = !disabled;
            btnupRules.IsEnabled = !disabled;
        }

        private async Task TryToManipulateRulesWrapperAsync(HttpResponseMessage rulesResponse, bool notUpdate)
        {
            var responseContent = rulesResponse.Content;
            await GenericBadRequestManagerAsync(rulesResponse, responseContent);
            rulesTable.ItemsSource = new List<Rules>() { await rulesResponse.Content.ReadAsAsync<Rules>() };
            if (!notUpdate)
            {
                DisabledAllInRulesPanel(false);
                AppMessageDialog.Show("Se ha realizado la actualización con éxito.");
                txtPdfPath.Text = null;
                txtPR.Text = null;
                txtSR.Text = null;
                txtGR.Text = null;
                fileName = null;
            }

        }


        // Eventos Datos::tablecard : Los eventos relacionados con el panel de TABLA. 

        private async void OnClickResetTemp(object sender, RoutedEventArgs e)
        {

            var questDialog = AppQuestDialog.Show("¿Seguro que quieres terminar la temporada?");
            if (questDialog.Result)
            {
                try
                {
                    ringActive();
                    var seasonResponse = await seasonRestClientService.resetSeason();
                    var responseContent = seasonResponse.Content;
                    await GenericBadRequestManagerAsync(seasonResponse, responseContent);
                    if (await responseContent.ReadAsAsync<bool>() == false)
                    {
                        throw new Exception("Algo inesperado ha ocurrido al restablecer los datos en el servidor.");
                    }
                    await LoadPlayerDataTableWithSimpleDataAsync("Se ha terminado la temporada! Se enviará una notificación a todos los jugadores.", resultTable);
                }
                catch (Exception ex)
                {
                    AppWarnDialog.Show(ex.Message);
                }
                ringDisabled();
            }

        }

        private async void OnResultsCard_IsVisible(object sender, DependencyPropertyChangedEventArgs e)
        {

            var card = sender as Card;
            if (card.Visibility == Visibility.Visible)
            {
                try
                {
                    ringActive();
                    await LoadPlayerDataTableWithSimpleDataAsync(null, resultTable);
                }
                catch (Exception ex)
                {
                    AppWarnDialog.Show(ex.Message);
                }
                ringDisabled();
            }

        }

        ///GENERICS METHODS

        static List<Player> lstOfPlayers;

        private async Task GetPlayerSimpleDataAndShowAsync(Task<HttpResponseMessage> playersAsyncResponse, DataGrid table)
        {
            var playerResponse = await playersAsyncResponse;
            if (!playerResponse.IsSuccessStatusCode)
            {
                throw new Exception(await playerResponse.Content.ReadAsStringAsync());
            }
            lstOfPlayers = await playerResponse.Content.ReadAsAsync<List<Player>>();
            table.ItemsSource = lstOfPlayers;
        }

        private async Task LoadPlayerDataTableWithSimpleDataAsync(String message, DataGrid table)
        {
            var playersAsyncResponse = playerRestClientService.getPlayers(RestConstants.PLAYER_DATA_SIMPLE_WITH_ID);
            if (message != null)
            {
                AppMessageDialog.Show(message);
            }
            await GetPlayerSimpleDataAndShowAsync(playersAsyncResponse, table);
        }

        // Eventos Datos::playerscard : Los eventos relacionados con el panel de JUGADORES.

        private async void OnClickAddPlayer(object sender, RoutedEventArgs e)
        {

            var player = new Player();
            try
            {
                ringActive();
                player.playerNick = txtPlayerName.Text;
                player.playerMail = txtPlayerMail.Text;
                var insertResponse = await playerRestClientService.insertOnePlayer(player);
                var responseContent = insertResponse.Content;
                await GenericBadRequestManagerAsync(insertResponse, responseContent);
                var message = "Se ha añadido con éxito " + player.playerNick + " con mail " + player.playerMail + ", comienza con un total de " + player.playerTotalPoints + " puntos.";
                await LoadPlayerDataTableWithSimpleDataAsync(message, playersTable);
                txtPlayerName.Text = EMPTY_STR;
                txtPlayerMail.Text = EMPTY_STR;
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnClickDeletePlayer(object sender, RoutedEventArgs e)
        {

            try
            {
                ringActive();
                var messages = new String[] { "Solo puedes borrar de uno en uno.", "Debes seleccionar un jugador de la tabla para eliminarlo.", "¿Seguro que quieres eliminar el jugador?" };
                var questDialog = ValidateIfAreValidInputs(messages);
                if (questDialog.Result)
                {
                    Func<Player, bool> isThisPlayer = pl => pl.playerNick.Equals(((Player)playersTable.SelectedValue).playerNick);
                    var player = lstOfPlayers.First(isThisPlayer);
                    var deletedResponse = await playerRestClientService.deleteOnePlayer(player);
                    var responseContent = deletedResponse.Content;
                    await GenericBadRequestManagerAsync(deletedResponse, responseContent);
                    if (await responseContent.ReadAsAsync<bool>() == false)
                    {
                        throw new Exception("Hubo un problema al borrar el jugador.");
                    }
                    await LoadPlayerDataTableWithSimpleDataAsync("El jugador fue borrado con éxito.", playersTable);
                }
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnClickUpdatePlayer(object sender, RoutedEventArgs e)
        {

            try
            {
                ringActive();
                var messages = new String[] { "Solo puedes actualizar de uno en uno.", "Debes seleccionar un jugador de la tabla para actualizarlo", "¿Seguro que quieres actualizar al jugador?" };
                var questDialog = ValidateIfAreValidInputs(messages);
                if (questDialog.Result)
                {
                    Func<Player, bool> isThisPlayer = pl => pl.playerNick.Equals(((Player)playersTable.SelectedValue).playerNick);
                    var player = lstOfPlayers.First(isThisPlayer);
                    player.playerNick = txtPlayerName.Text;
                    player.playerMail = txtPlayerMail.Text;
                    var updateResponse = await playerRestClientService.updateOnePlayer(player);
                    var responseContent = updateResponse.Content;
                    await GenericBadRequestManagerAsync(updateResponse, responseContent);
                    var message = "Se ha actualizado con éxito " + player.playerNick + " con mail " + player.playerMail;
                    await LoadPlayerDataTableWithSimpleDataAsync(message, playersTable);
                    txtPlayerName.Text = EMPTY_STR;
                    txtPlayerMail.Text = EMPTY_STR;
                }
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnPlayersCard_IsVisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            var card = sender as Card;
            if (card.Visibility == Visibility.Visible)
            {
                try
                {
                    ringActive();
                    await LoadPlayerDataTableWithSimpleDataAsync(null, playersTable);
                }
                catch (Exception ex)
                {
                    AppWarnDialog.Show(ex.Message);
                }
                ringDisabled();
            }

        }

        private AppQuestDialog ValidateIfAreValidInputs(string[] messages)
        {
            if (playersTable.SelectedItems.Count > 1)
            {
                throw new Exception(messages[0]);
            }
            if (playersTable.SelectedItem == null)
            {
                throw new Exception(messages[1]);
            }
            return AppQuestDialog.Show(messages[2]);
        }
        // Eventos Datos::teamscard : Los eventos relacionados con el panel de EQUIPOS.

        private async void OnClickAddTeam(object sender, RoutedEventArgs e)
        {

            var team = new Team();
            try
            {
                ringActive();
                team.teamName = txtTeamName.Text;
                var insertResponse = await teamRestClienService.insertOneTeam(team);
                var insertContent = insertResponse.Content;
                await GenericBadRequestManagerAsync(insertResponse, insertContent);
                var teaminserted = await insertContent.ReadAsAsync<Team>();
                AppMessageDialog.Show("Se insertó " + teaminserted.teamName + " correctamente");
                txtTeamName.Text = EMPTY_STR;
                await LoadTeamsDataTable();
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnTeamsCard_IsVisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ringActive();
                var card = sender as Card;
                if (card.Visibility == Visibility.Visible)
                {
                    await LoadTeamsDataTable();
                }
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnClickDeleteSelected(object sender, RoutedEventArgs e)
        {
            try
            {
                ringActive();
                if (teamsTable.SelectedItems.Count > 1)
                {
                    throw new Exception("Solo puedes borrar de uno en uno.");
                }
                if (teamsTable.SelectedItem == null)
                {
                    throw new Exception("Debes seleccionar un equipo de la tabla para eliminarlo");
                }
                var questDialog = AppQuestDialog.Show("¿Seguro que quieres eliminar el equipo?");

                if (questDialog.Result)
                {
                    var team = ((Team)teamsTable.SelectedValue);
                    var deletedResponse = await teamRestClienService.deleteOneTeam(team);
                    var deletedContent = deletedResponse.Content;
                    await GenericBadRequestManagerAsync(deletedResponse, deletedContent);
                    var deleteSucces = await deletedContent.ReadAsAsync<bool>();
                    if (!deleteSucces)
                    {
                        throw new Exception("Problema no identificado al tratar de borrar el equipo seleccionado.");
                    }
                    AppMessageDialog.Show(team.teamName + " fue borrado con éxito.");
                    await LoadTeamsDataTable();
                }
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }



        private async Task LoadTeamsDataTable()
        {
            try
            {
                ringActive();
                var teamsResponse = await teamRestClienService.getTeams();
                var teamsContent = teamsResponse.Content;
                await GenericBadRequestManagerAsync(teamsResponse, teamsContent);
                teamsTable.ItemsSource = await teamsContent.ReadAsAsync<List<Team>>();
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }
        // Eventos Datos::journeycard : Los eventos relacionados con el panel de JORNADA.


        static ConcreteMatch openConcreteMatch;

        private void OnClickOpenNewJourney(object sender, RoutedEventArgs e)
        {

            if (openConcreteMatch != null)
            {
                ringActive();
                AppMessageDialog.Show("Aún existe una jornada abierta.\nNo puedes abrir una nueva hasta que finalice");
                ringDisabled();
            }
            else
            {
                cardJourney.Visibility = Visibility.Hidden;
                OnClickShow(sender, e);
            }

        }
        private void OnCardJourney_IsVisibilityChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (cardJourney.Visibility == Visibility.Visible)
            {
                GetOpenConcreteMatch();
            }
        }


        private async void OnClickOpenActualJourney(object sender, RoutedEventArgs e)
        {
            try
            {
                ringActive();
                var players = await playerRestClientService.getPlayers(0);
                var playersContent = players.Content;
                await GenericBadRequestManagerAsync(players, playersContent);
                var playerLst = await playersContent.ReadAsAsync<List<Player>>();
                if (openConcreteMatch == null)
                {
                    throw new Exception("Aún no existe una jornada abierta.");
                }
                else if (playerLst.Count < 1)
                {
                    throw new Exception("No se pueden realizar apuestas ya que aún no hay participantes.");
                }
                else
                {
                    cardJourney.Visibility = Visibility.Hidden;
                    OnClickShow(sender, e);
                }
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }


        private async void GetOpenConcreteMatch()
        {
            try
            {
                ringActive();
                var openConcreteMatchResponse = await concreteMatchRestClientService.getOpenMatch();
                var responseContent = openConcreteMatchResponse.Content;
                await GenericBadRequestManagerAsync(openConcreteMatchResponse, responseContent);
                openConcreteMatch = await responseContent.ReadAsAsync<ConcreteMatch>();
            }
            catch { }
            ringDisabled();
        }

        // Eventos Datos::journeyInit : Los eventos relacionados con el panel de ABRIR JORNADA.

        private void Back_I_ToInitial(object sender, RoutedEventArgs e)
        {
            cardInitJourney.Visibility = Visibility.Hidden;
            cardJourney.Visibility = Visibility.Visible;
            combLocal.Text = EMPTY_STR;
            combVisit.Text = EMPTY_STR;
        }



        private async void OnVisibility_Visible_LoadTeams(object sender, DependencyPropertyChangedEventArgs e)
        {
            try
            {
                ringActive();
                var teamsActualResponse = await teamRestClienService.getTeams();
                var responseContent = teamsActualResponse.Content;
                await GenericBadRequestManagerAsync(teamsActualResponse, responseContent);
                var teamsActual = await responseContent.ReadAsAsync<List<Team>>();
                var teamsNameActual = teamsActual.ConvertAll(team => team.teamName);
                combLocal.ItemsSource = teamsNameActual;
                combVisit.ItemsSource = teamsNameActual;

            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnClickAcceptMatch(object sender, RoutedEventArgs e)
        {
            var localTxt = combLocal.Text;
            var visitanteTxt = combVisit.Text;
            try
            {
                ringActive();
                var concreteMatch = new ConcreteMatch();
                concreteMatch.localTeam = localTxt;
                concreteMatch.visitorTeam = visitanteTxt;
                var acceptMatchResponse = await concreteMatchRestClientService.insertConcreteMatch(concreteMatch);
                var responseContent = acceptMatchResponse.Content;
                await GenericBadRequestManagerAsync(acceptMatchResponse, responseContent);
                var concreteMatchInserted = await responseContent.ReadAsAsync<ConcreteMatch>();
                AppMessageDialog.Show("Se ha iniciado la jornada: " + concreteMatchInserted.localTeam + " vs " + concreteMatchInserted.visitorTeam);
                Back_I_ToInitial(sender, e);
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        // Eventos Datos::journeyActual : Los eventos relacionados con el panel de JORNADA ACTUAL.

        private void OnActualJourney_IsVisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (cardActualJourney.Visibility == Visibility.Visible)
            {
                try
                {
                    ringActive();
                    journeyTitle.Text = openConcreteMatch.localTeam + " VS " + openConcreteMatch.visitorTeam;
                    CleanComponents();
                    LoadDataJourneyContainers();
                }
                catch (Exception ex)
                {
                    AppWarnDialog.Show(ex.Message);
                }
                ringDisabled();
            }

        }

        private void CleanComponents()
        {
            combPlayers.ItemsSource = null;
            inputLocal.Text = EMPTY_STR;
            inputVisit.Text = EMPTY_STR;
            inputLocPl.Text = EMPTY_STR;
            inputVisPl.Text = EMPTY_STR;
        }

        private async void LoadDataJourneyContainers()
        {
            try
            {
                ringActive();
                var jouneyplfmDataResponse = await footballDayRestClientService.getAllData();
                var responseContent = jouneyplfmDataResponse.Content;
                await GenericBadRequestManagerAsync(jouneyplfmDataResponse, responseContent);
                var lstOfDataList = await responseContent.ReadAsAsync<PlayerListWrapper>();
                journTable.ItemsSource = lstOfDataList.playersDataWithResult;
                combPlayers.ItemsSource = lstOfDataList.playersWithoutResult.ConvertAll(pl => pl.playerNick);
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private void Back_A_ToInitial(object sender, RoutedEventArgs e)
        {
            cardActualJourney.Visibility = Visibility.Hidden;
            cardJourney.Visibility = Visibility.Visible;
            CleanComponents();
        }


        private async void OnClickAddPlayerResult(object sender, RoutedEventArgs e)
        {
            ringActive();
            var plftMatch = new PlayerFootballMatch();
            var txtloc = inputLocPl.Text;
            var txtvis = inputVisPl.Text;
            try
            {
                var goalsLoc = short.Parse(txtloc);
                var goalsVis = short.Parse(txtvis);
                var localteam = openConcreteMatch.localTeam;
                plftMatch.burgosCFGoals = localteam.Equals(RestConstants.BCF) ? goalsLoc : goalsVis;
                plftMatch.playerFootBallMatchResult = goalsLoc + "-" + goalsVis;
                var sign = goalsLoc > goalsVis ? 1 : goalsLoc < goalsVis ? 2 : 0;
                plftMatch.winnerSign = (short)sign;
                plftMatch.playerNick = combPlayers.Text;
                var insertPlfmResponse = await footballDayRestClientService.insertOnePlayerResult(plftMatch);
                var responseContent = insertPlfmResponse.Content;
                await GenericBadRequestManagerAsync(insertPlfmResponse, responseContent);
                CleanComponents();
                LoadDataJourneyContainers();
                AppMessageDialog.Show("Se insertó el resultado de la jornada del jugador " + combPlayers.Text);
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }


        private async void OnClickDeleteJourney(object sender, RoutedEventArgs e)
        {
            var responseDialog = AppQuestDialog.Show("Seguro que quieres eliminar la jornada");
            if (responseDialog.Result)
            {
                try
                {
                    ringActive();

                    var deleteJourneyResponse = await concreteMatchRestClientService.deleteOpenConcreteMatch();
                    var responseContent = deleteJourneyResponse.Content;
                    await GenericBadRequestManagerAsync(deleteJourneyResponse, responseContent);
                    CleanComponents();
                    if (await responseContent.ReadAsAsync<bool>() == false)
                    {
                        throw new Exception("Ocurrió algo inesperado al tratar de borrar el partido.");
                    }
                    openConcreteMatch = null;
                    AppMessageDialog.Show("Se borró el partido con éxito.");
                    Back_A_ToInitial(sender, e);
                }
                catch (Exception ex)
                {
                    AppWarnDialog.Show(ex.Message);
                }
            }
            ringDisabled();
        }

        private async void OnClickCloseJourney(object sender, RoutedEventArgs e)
        {
            try
            {
                ringActive();
                var lGoals = inputLocal.Text;
                var vGoals = inputVisit.Text;
                var result = lGoals + "-" + vGoals;
                openConcreteMatch.resultOfConcreteMatch = result;
                var endJourneyResponse = await footballDayRestClientService.endTheFootballDay(openConcreteMatch);
                var responseContent = endJourneyResponse.Content;
                await GenericBadRequestManagerAsync(endJourneyResponse, responseContent);
                CleanComponents();
                var concreteMatch = await responseContent.ReadAsAsync<ConcreteMatch>();
                journTable.ItemsSource = concreteMatch.lstOfPlayerFootballMatch;
                AppMessageDialog.Show("La jornada ha finalizado, puedes ver los resultados en la tabla.");
                openConcreteMatch = null;
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private void Back_C_ToInitial(object sender, RoutedEventArgs e)
        {
            txtErrMsg.Text = EMPTY_STR;
            txtLicense.Text = EMPTY_STR;
            cardSupport.Visibility = Visibility.Hidden;
            cardAdjust.Visibility = Visibility.Visible;
        }

        private async void OnClick_ShowLicense(object sender, RoutedEventArgs e)
        {
            try
            {
                ringActive();
                var licenseResponse = await downloadLicenseRestClientService.serveApplicationLicense();
                var responseContent = licenseResponse.Content;
                await GenericBadRequestManagerAsync(licenseResponse, responseContent);
                txtLicense.Text = await responseContent.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }

        private async void OnClick_SendErrorMessageToSupport(object sender, RoutedEventArgs e)
        {
            try
            {
                ringActive();
                var errorMessage = txtErrMsg.Text;
                txtErrMsg.Text = EMPTY_STR;
                var logsResponse = await sendLogsRestClientService.sendLogsToApplicationSupport(errorMessage);
                var responseContent = logsResponse.Content;
                await GenericBadRequestManagerAsync(logsResponse, responseContent);
                if (responseContent.ReadAsAsync<bool>().Result == false)
                {
                    throw new Exception("Ha ocurrido algún tipo de problema al mandar la notificación a soporte.");
                }
                AppMessageDialog.Show("Se ha avisado con éxito a soporte. Pronto recibirás noticias.");
            }
            catch (Exception ex)
            {
                AppWarnDialog.Show(ex.Message);
            }
            ringDisabled();
        }
        private const string CHAR_LIMIT = "/500";
        private void OnTxtErrMsgChanged_UpdateCharLabel(object sender, TextChangedEventArgs e)
        {
            charLbl.Content = txtErrMsg.Text.Length + CHAR_LIMIT;
        }
        private async Task GenericBadRequestManagerAsync(HttpResponseMessage insertPlfmResponse, HttpContent responseContent)
        {
            if (!insertPlfmResponse.IsSuccessStatusCode)
            {
                var errorMessage = await responseContent.ReadAsAsync<ErrorWrapper>();
                throw new Exception(errorMessage.MessageFormatted());
            }
        }

        private void On_CarSupport_IsVisible(object sender, DependencyPropertyChangedEventArgs e)
        {
            charLbl.Content = cardSupport.Visibility == Visibility.Visible ? 0 + CHAR_LIMIT : null;
        }
        private void ringActive()
        {
            ringAwait.IsActive = true;
            this.Opacity = 0.7;
        }
        private void ringDisabled()
        {
            ringAwait.IsActive = false;
            this.Opacity = 1;
        }

    }
}