   M S B A M L   `   `   `  ????>  :P16, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:P16P16  5   	       P16.Window2   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:P16     5   	     ? Title$  Window2??5   	   $	??450??6   $	??800??6&    ? ContextMenu 5	      ?? 5
   
   .@?5      m? -   5        $??Добавить??5      6)   m? 5      -   5        $)??#Посмотреть покупки??5      63   m? 5      -   5        $??Удалить??5      6(   5      .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??70* ?6   ?? 5      $	??30* ?6   .+?5   
   &   System.Windows.Controls.DataGrid  -   5          Name$
 grid??5      $ ?? IsSynchronizedWithCurrentItem$
 TrueY?5         SelectionMode$ Single=?5         AutoGenerateColumns .     
IsReadOnly .  ??5      ??    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5       -   5        ID??,  &System.Windows.Controls.DataGridColumn	   Header$	 ID??5!   %   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 5"   %   ?? *ID+  5#      -   5        Surname??$	 Фамилия??5$   %   
 5%   %   ?? *	Surname+  5&      -   5        Name??$	 Имя??5'   %   
 5(   %   ?? *Name+  5)      -   5        	Name2??$	 Отчество??5*   %   
 5+   %   ?? *Name2+  5,      -	   5        	Phone??$!	 Номер телефона??5-   %   
 5.   %   ?? *Phone+  5/      -
   5        	Email??$	 Email??50   %   
 51   %   ?? *Email+53      ?? 54   
   -   5         ??Name$ showlo??54      $?? ??6    $??1??6+   $
??Left=?6;   $??
52,100,0,0q?6V   $	??Top=?6j   $	??100??6?   55      56      