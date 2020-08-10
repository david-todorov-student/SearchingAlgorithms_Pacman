from pacman import *
from searching_framework.uninformed_search import *
# 0
# 0
# istok
# 5
# 2,6
# 4,0
# 6,5
# 8,2
# 8,3
if __name__ == "__main__":
    pacman_x = 0  # int(input())
    pacman_y = 9  # int(input())
    direction = "istok"  # input()
    N = 5  # int(input())
    dots = ((3, 2), (4, 6), (6, 8), (7, 8), (9, 4))  # tuple([tuple(map(int, input().split(','))) for i in range(N)])
    goal_dots = ()
    pacman = (pacman_x, pacman_y, direction)
    problem = Pacman((pacman, dots), goal_dots)
    result = breadth_first_graph_search(problem)
    print(result.solution())
