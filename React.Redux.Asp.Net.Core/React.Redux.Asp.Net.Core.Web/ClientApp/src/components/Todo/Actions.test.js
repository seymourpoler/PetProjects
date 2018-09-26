import { REMOVE_TODO_ITEM, ADD_TODO_ITEM } from './Actions.Types';
import { removeTodo, addTodo } from './Actions';

describe('when action requested', () => {
    it('removes todo item', () => {
        const id = 1;

        let result = removeTodo(id);

        expect(result.type).toBe(REMOVE_TODO_ITEM);
        expect(result.payload).toBe(id);
    });

    it('adds todo item', () => {
        const item = { id: 1, title: 'title', description: 'description' };

        let result = addTodo(item);

        expect(result.type).toBe(ADD_TODO_ITEM);
        expect(result.payload).toBe(item);
    });
});

