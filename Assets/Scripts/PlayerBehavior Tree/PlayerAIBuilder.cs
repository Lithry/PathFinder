using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIBuilder {
	public BTNode<Blackboard> BuildAI(Blackboard blackboard) {
		Selector<Blackboard> root = new Selector<Blackboard>(blackboard);
		
		Sequence<Blackboard> mine = new Sequence<Blackboard>(blackboard);
		root.AddChildren(mine);

		Conditional<Blackboard> askIsAMine = new AskIsAMine(blackboard);
		mine.AddChildren(askIsAMine);

		Decorator<Blackboard> decorator = new Decorator<Blackboard>(blackboard);
		Conditional<Blackboard> askIsEmpty = new AskMineIsEmpty(blackboard);
		decorator.AddChildren(askIsEmpty);
		mine.AddChildren(decorator);

		Action<Blackboard> goTo = new GoTo(blackboard);
		mine.AddChildren(goTo);

        Action<Blackboard> mining = new MineMaterials(blackboard);
        mine.AddChildren(mining);

        Action<Blackboard> goHome = new GoDeposite(blackboard);
        mine.AddChildren(goHome);

        Action<Blackboard> deposit = new DepositeOnHome(blackboard);
        mine.AddChildren(deposit);

        Sequence<Blackboard> move = new Sequence<Blackboard>(blackboard);
        move.AddChildren(goTo);

        root.AddChildren(move);

		return root;
	}
}