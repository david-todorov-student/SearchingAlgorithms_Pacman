from searching_framework.utils import Problem
from copy import deepcopy

def move_forward(man_x, man_y, direction):
    if direction == "istok":
        return man_x + 1, man_y, direction
    elif direction == "zapad":
        return man_x - 1, man_y, direction
    elif direction == "sever":
        return man_x, man_y + 1, direction
    elif direction == "jug":
        return man_x, man_y - 1, direction


def move_backward(man_x, man_y, direction):
    if direction == "istok":
        return man_x - 1, man_y, "zapad"
    elif direction == "zapad":
        return man_x + 1, man_y, "istok"
    elif direction == "sever":
        return man_x, man_y - 1, "jug"
    elif direction == "jug":
        return man_x, man_y + 1, "sever"


def move_left(man_x, man_y, direction):
    if direction == "istok":
        return man_x, man_y + 1, "sever"
    elif direction == "zapad":
        return man_x, man_y - 1, "jug"
    elif direction == "sever":
        return man_x - 1, man_y, "zapad"
    elif direction == "jug":
        return man_x + 1, man_y, "istok"


def move_right(man_x, man_y, direction):
    if direction == "istok":
        return man_x, man_y - 1, "jug"
    elif direction == "zapad":
        return man_x, man_y + 1, "sever"
    elif direction == "sever":
        return man_x + 1, man_y, "istok"
    elif direction == "jug":
        return man_x - 1, man_y, "zapad"


def manhattan_distance(dot1, dot2):
    x1, y1 = dot1[0], dot1[1]
    x2, y2 = dot2[0], dot2[1]
    return abs(x1 - x2) + abs(y1 - y2)


class Pacman(Problem):
    def __init__(self, initial, goal=None):
        self.initial = initial
        self.obstacles = [(0, 6), (0, 8), (0, 9), (1, 2), (1, 3), (1, 4), (1, 9),
                          (2, 9), (3, 6), (3, 9), (4, 1), (4, 5), (4, 6), (4, 7),
                          (5, 1), (5, 6), (6, 0), (6, 1), (6, 2), (6, 9), (8, 1),
                          (8, 4), (8, 7), (8, 8), (9, 4), (9, 7), (9, 8)]
        self.goal = goal

    def successor(self, state):
        """За дадена состојба, врати речник од парови {акција : состојба}
        достапни од оваа состојба. Ако има многу следбеници, употребете
        итератор кој би ги генерирал следбениците еден по еден, наместо да
        ги генерирате сите одеднаш.

        :param state: дадена состојба
        :return:  речник од парови {акција : состојба} достапни од оваа
                  состојба
        :rtype: dict
        """
        successors = dict()

        man_x = state[0][0]
        man_y = state[0][1]
        direction = state[0][2]
        food = list(state[1])

        forward_x, forward_y, forward_dir = move_forward(man_x, man_y, direction)
        if (0 <= forward_x <= 9 and 0 <= forward_y <= 9) and (forward_x, forward_y) not in self.obstacles:
            temp_food = deepcopy(food)
            if (forward_x, forward_y) in temp_food:
                temp_food.remove((forward_x, forward_y))
            successors["ProdolzhiPravo"] = ((forward_x, forward_y, forward_dir), tuple(temp_food))

        backward_x, backward_y, backward_dir = move_backward(man_x, man_y, direction)
        if (0 <= backward_x <= 9 and 0 <= backward_y <= 9) and (backward_x, backward_y) not in self.obstacles:
            temp_food = deepcopy(food)
            if (backward_x, backward_y) in temp_food:
                temp_food.remove((backward_x, backward_y))
            successors["ProdolzhiNazad"] = ((backward_x, backward_y, backward_dir), tuple(temp_food))

        left_x, left_y, left_dir = move_left(man_x, man_y, direction)
        if (0 <= left_x <= 9 and 0 <= left_y <= 9) and (left_x, left_y) not in self.obstacles:
            temp_food = deepcopy(food)
            if (left_x, left_y) in temp_food:
                temp_food.remove((left_x, left_y))
            successors["SvrtiLevo"] = ((left_x, left_y, left_dir), tuple(temp_food))

        right_x, right_y, right_dir = move_right(man_x, man_y, direction)
        if (0 <= right_x <= 9 and 0 <= right_y <= 9) and (right_x, right_y) not in self.obstacles:
            temp_food = deepcopy(food)
            if (right_x, right_y) in temp_food:
                temp_food.remove((right_x, right_y))
            successors["SvrtiDesno"] = ((right_x, right_y, right_dir), tuple(temp_food))

        return successors

    def actions(self, state):
        """За дадена состојба state, врати листа од сите акции што може да
        се применат над таа состојба

        :param state: дадена состојба
        :return: листа на акции
        :rtype: list
        """
        return self.successor(state).keys()

    def result(self, state, action):
        """За дадена состојба state и акција action, врати ја состојбата
        што се добива со примена на акцијата над состојбата

        :param state: дадена состојба
        :param action: дадена акција
        :return: резултантна состојба
        """
        return self.successor(state)[action]

    def h(self, node):
        man = node.state[0][0], node.state[0][1]
        food = [t for t in node.state[1]]
        max_distance=0
        for f in food:
            dist = manhattan_distance(man, f)
            if dist>max_distance:
                max_distance = dist
        return max_distance


    def goal_test(self, state):
        """Врати True ако state е целна состојба. Даденава имплементација
        на методот директно ја споредува state со self.goal, како што е
        специфицирана во конструкторот. Имплементирајте го овој метод ако
        проверката со една целна состојба self.goal не е доволна.

        :param state: дадена состојба
        :return: дали дадената состојба е целна состојба
        :rtype: bool
        """
        return state[1] == self.goal