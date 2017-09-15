using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAIBuilder {
	public BTNode<Blackboard> BuildAI(Blackboard blackboard){
		Sequence<Blackboard> root = new Sequence<Blackboard>(blackboard);
		
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

		return root;
	}
}