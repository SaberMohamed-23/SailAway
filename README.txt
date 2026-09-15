SAILAWAY WINDOWS FORMS INTERFACE

Open SailAway_WinForms_Interface.sln in Visual Studio 2022.
This project contains 25 Windows Forms screens based on the SailAway UI design.

Important:
- The UI is made with standard WinForms controls in *.Designer.cs, like Visual Studio drag-and-drop generates.
- No database is connected yet. Sample rows are only there to make the interface visible.
- Start form: FrmStart.
- Admin start form is FrmBeheerMenu; you can temporarily change Program.cs to Application.Run(new FrmBeheerMenu()); to preview it.
- Target framework: .NET 8 Windows.


FIX DESIGNER COMPATIBILITEIT
- Inline lambda Click-events zijn uit InitializeComponent verwijderd.
- Event-handlers voor Annuleren/Terug en het beheermenu staan nu in de normale .cs code-behind.
- Hierdoor kan Visual Studio de Windows Forms Designer de formulieren normaal laden en kun je ze via drag-and-drop aanpassen.
