#Video Game Console Sales/Storefront app & Collection Databse

This is a console application that works as a storefront to check out/sell consoles, access external text file of current collection and a wishlist system. This program allows users to enter systems they are interested in purchasing or selling consoles but it can be refactored to do whatever the user wants. Users can add mulitiple itmes to their cart, get a price total and check out with all or a selection fo what they want. The second part was to build a wishlist of games that rights and reads to a .csv file. Lastly, My goal was to allow a quick and easy way to reccomend a random game from an external source that can be applied by anyone who has data posted in a raw file online. 

Follow the prompts after compiling to execute the program. To run, navigate to Program.cs in the VGShopConsoleApp folder, compile and run. The repo is located at https://github.com/dd1x0n/VideoGameLIbrary-Shop/tree/master 

Optional Requiremnts Used in Program:
1.) "Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program." - This program allows users to enter data in order to sell multiple video game consoles and checkpout with final price. Users can choose all or a single item in the cart. 

2.) & 3. ) "Create a class, then create at least one object of that class and populate it with data. / Create another class which inherits one or more properties from its parent." - This option is fullfilled thought the program particualrly in the checkout stage of the program. Data population comes from an eternal pasebin file wich is then manipulated and a .csv wishlist. 

4.) "Read data from an external file, such as text, JSON, CSV, etc and use that data in your
application" -  Program reads from two sourses, Patebin and wishlist.csv. 

5.) "Create a call at least 3 functions or methods, at least one of which must return a value that is used in your application" - used in checkout stage of application.

6.) "Analyze text and display information about it (ex: how many words in a paragraph)" - This is used to count the itmes in the wishlist fucntion. 

WARNING: Two sets files outside of the main program are referenced so make sure that is implemented in your IDE. This was built with Visual Studio for Mac.
