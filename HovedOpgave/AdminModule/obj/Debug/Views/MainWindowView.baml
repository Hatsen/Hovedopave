   M S B A M L   `   `   `  ����  AdminModule&     AdminModule.Views.MainWindowView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   X TXceed.Wpf.Toolkit, Version=2.3.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f47toolkit)http://schemas.xceed.com/wpf/xaml/toolkit  5        � Title$  Birkeallé kontrolcenter��5      $��732.575��6,   $��1155.245��6=   .��5      %  Xceed.Wpf.Toolkit.BusyIndicator     BusyContent$ Vent venligst...��69      IsBusy 6   �� *	Isloading+.��5   
   � 
�����_� � RowDefinitions 5	      �� 5
      $��20 �6    �� 5      $
��Auto �6    .+�5      o� $��0��6   .@�5      m� $��_Filer��6   .@�5      m� $��Afslut��6H    m� Command 6   �� *CreateStudentCommand+6H   5      m� 5      $��_Hjælp��6   .@�5      m� $��Reset Password��6H    6   �� *ResetPasswordCommand+6H   m� 5      $��Se tilknyttede børn��6J    6   �� *SeeAssociationsCommand+6J   5      5      � 5      $��1��6   $��2��6   .+�5      �� $
��Søg��6   $
��Left=�6'   $��
439,24,0,0q�6B   $	��Top=�6V   $��81��6n   $��25��6y   ��6�   �� *UpdateCommand+&   System.Windows.Controls.DataGrid  5      -   5        $��datagridUser��5         SelectionMode$ Single=�6/   $
��Left=�6F   $	��Top=�6a   $	��352��6y   $	��400��6�   $��
120,51,0,0q�6�      AutoGenerateColumns .     CanUserAddRows .  ��6�   �� *TeacherList+ �� Mode$ TwoWay=�	 �� SelectedItem	 6�   �� *SelectedUser+$ TwoWay=�
   Columns
 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Fornavn��6K      
IsReadOnly .    Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6n      CanUserResize .  1  +System.Windows.Controls.DataGridBoundColumn   Binding 6-   �� *	Firstname+6y     5      $ 	Efternavn��6J    . $ 80 6o    .   6-   �� *
Lastname+6z     5      $ By��6F    . $ 80 6d    .   6-   �� *City+6o     5      $ Adresse��6I    . $ 80 6l    .   6-   �� *	Address+6w     5      $ Stilling��6G    . $ 80 6k    .   6-   �� *Title+6v      RowDetailsTemplate 5       �� 5!      .R�5"      �� $��0q�6%   
������� �� Padding$ 10q�6P   ._�5#   "   ��  �� Orientation$ Vertical=�6-   .+�5$   &   �� $ 
Horizontal=�61   .+�5%   *   �� $��12(�64   $
��Id: ��6B   $��Center=�6N   �� 5&   *   $��16(�64   
���p�$��Center=�6p   ��6\   �� *Id+6p   5'   '   �� 5(   &   $ 
Horizontal=�61   .+�5)   *   �� $��12(�64   $��Seneste login: ��6B   $��Center=�6Y   �� 5*   *   $��16(�64   
���p�$��Center=�6w   ��6\   �� *	Lastlogin+6w   5+   '   �� 5,   &   $ 
Horizontal=�61   .+�5-   *   �� $��12(�64   $��
Userrole: ��6B   $��Center=�6T   �� 5.   *   $��16(�64   
���p�$��Center=�6v   ��6\   �� *
Userrole+6v   5/   '   �� 50   &   $ 
Horizontal=�61   .+�51   *   �� $��12(�64   $��
Username: ��6B   $��Center=�6T   �� 52   *   $��16(�64   
���p�$��Center=�6v   ��6\   �� *
Username+6v   53   '   �� 54   &   $ 
Horizontal=�61   .+�55   *   �� $��12(�64   $��	Telefon: ��6B   $��Center=�6S   �� 56   *   $��16(�64   
���p�$��Center=�6y   ��6\   �� *Phonenumber+6y   57   '   58   #   59      5:       � ContextMenu 5<      �� 5=      .@�5>      m� $��Se tilknytninger��6'    6A   �� *SeeAssociationsCommand+5?      m� 5@      $!��Reset Password for brugeren��6'    6L   �� *ResetPasswordCommand+5A      5B      5D      �� 5E      $
��Left=�6   $	��Top=�66   $	��192��6N   $��25��6Z   $��
120,24,0,0q�6f   ��6z   �� *PersonStringList+$ TwoWay=�	 6�   �� *SelectedStringPerson+$ TwoWay=��� 5F      $
��Left=�6   $��25��65   $��
317,24,0,0q�6A    �� TextWrapping$
 Wrap=�6U   $��Søg...��6i   $	��Top=�6x   $	��117��6�   �� 5G      $��Rediger Person��6   $
��Left=�62   $��
10,157,0,0q�6M   $	��Top=�6a   $	��105��6y   $��25��6�   ��6�   �� *EditUserCommand+�� 5H      $��Opret Underviser��6   $
��Left=�64   $��	10,48,0,0q�6O   $	��Top=�6b   $	��105��6z   $��25��6�   ��6�   �� *CreateTeacherCommand+�� 5I      $��
Opret Elev��6   $
��Left=�6.   $��	10,78,0,0q�6I   $	��Top=�6\   $	��105��6t   $��25��6�   ��6�   �� *CreateStudentCommand+�� 5J      $��Opret Forældre��6   $
��Left=�62   $��
10,108,0,0q�6M   $	��Top=�6a   $	��105��6y   $��25��6�   ��6�   �� *CreateParentCommand+  5K       .  $ Single=�67    .  $
��Left=�6e   $	��Top=�6�   $	��352��6�   $	��400��6�   $��
635,46,0,0q�6�   ��6�   �� *	ClassList+$ TwoWay=�	 6�   �� *SelectedClass+ 5L      �� 5M      .@�5N      m� $��Se tilknytninger��6'    6A   �� *SeeAssociationsCommand+5O      5P      
 5R        5S      $ KlasseId��6D    . $	 133 6h    .   6-   �� *Id+6�     5T      $
 Navn��6F    . $	 133 6f    .   6-   �� *Name+6�     5U      $ 
Underviser��6S    . $	 133 6y    .   6-   �� *AssociatedTeacher+6�   5X      �� 5Y      $
��Left=�6   $��25��65   $��
844,20,0,0q�6A   $
 Wrap=�6U   $��Søg...��6i   $	��Top=�6x   $	��111��6�   �� 5Z      $��Opret klasse��6   $
��Left=�60   $��
525,48,0,0q�6K   $	��Top=�6_   $	��105��6w   $��25��6�   ��6�   �� *CreateClassCommand+�� 5[      $��Hent klasser��6   $
��Left=�60   $��
635,20,0,0q�6K   $	��Top=�6_   $	��204��6w   $��25��6�   ��6�   �� *GetClassesCommand+�� 5\      $
��Søg��6   $
��Left=�6'   $��
960,20,0,0q�6B   $	��Top=�6V   $��75��6n   $��25��6y   ��6�   �� *UpdateCommand+�� 5]      $��Rediger klasse��6   $
��Left=�62   $��
525,78,0,0q�6M   $	��Top=�6a   $	��105��6y   $��25��6�   ��6�   �� *EditClassCommand+�� 5^      $��Slet Person��6   $
��Left=�6/   $��
10,187,0,0q�6J   $	��Top=�6^   $	��105��6v   $��25��6�   ��6�   �� *DeleteUserCommand+�� 5_      $��Slet Klasse��6   $
��Left=�6/   $��525,108,0,0q�6J   $	��Top=�6_   $	��105��6w   $��25��6�   ��6�   �� *DeleteClassCommand+�� 5b      $��Bekræft indmeldelse��6   $
��Left=�67   $��525,649,0,-258q�6R   $	��Top=�6j   $	��115��6�   $��25��6�   ��6�   �� *ConfirmEnrollmentCommand+  5c       .  $ Single=�67    .  $
��Left=�6e   $	��Top=�6�   $	��236��6�   $	��400��6�   $��380,408,0,-228q�6�   ��6�   �� *EnrollmentList+$ TwoWay=�	 6�   �� *SelectedEnrollment+
 5e        5f      $ Barnets navn:��6P    . $	 133 6y    .   6-   �� *ChildFirstname+6�     5g      $ Bemærkninger:��6G    . $	 133 6p    .   6-   �� *Notes+6�     5h      $ 	Oprettet:��6M    . $	 133 6r    .   6-   �� *DateCreated+6�   5k      5m      �� 5n      $
��Left=�6   $��	138,5,0,0q�63   $��1��6F   $
��Wrap=�6S   $��Brugere:��6g   $	��Top=�6w   5o      5p      5q      