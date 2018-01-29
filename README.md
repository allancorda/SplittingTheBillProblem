# SplittingTheBillProblem
<br/>
A number of friends go camping every year at provincial parks. The group agrees in advance to share expenses equally, but it is not practical to have them share every expense as it occurs. So individuals in the group pay for particular things, like food, drinks, supplies, the camp site, parking, etc. After the camping trip, each person’s expenses are tallied and money is exchanged so that the net cost to each is the same. In the past, this money exchange has been tedious and time consuming. Your job is to compute, from a list of expenses, the amount of money that each person must pay or be paid.<br/><br/>

The Input<br/>
Standard input will contain the information for several camping trips. The information for each trip consists of a line containing a positive integer, n, the number of peopling participating in the camping trip, followed by n groups of inputs, one for each camping participant.  Each groups consists of a line containing a positive integer, p, the number of receipts/charges for that participant, followed by p lines of input, each containing the amount, in dollars and cents, for each charge by that camping participant.  A single line containing 0 follows the information for the last camping trip.<br/>
<br/>
The Output<br/>
For each camping trip, output one line per participant indicating how much he/she must pay or be paid rounded to the nearest cent.  If the participant owes money to the group, then the amount is positive.  If the participant should collect money from the group, then the amount is negative.  Negative amounts should be denoted by enclosing the amount in brackets.  Each trip should be separated by a blank line.<br/>
<br/>
Sample Input<br/>
3<br/>
2<br/>
10.00<br/>
20.00<br/>
4<br/>
15.00<br/>
15.01<br/>
3.00<br/>
3.01<br/>
3<br/>
5.00<br/>
9.00<br/>
4.00<br/>
2<br/>
2<br/>
8.00<br/>
6.00<br/>
2<br/>
9.20<br/>
6.75<br/>
0<br/>
<br/>
Output for Sample Input<br/>
($1.99)<br/>
($8.01)<br/>
$10.01<br/>
<br/>
$0.98<br/>
($0.98)<br/>
