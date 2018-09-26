import reducer from './Reducer';
import { REMOVE_TODO_ITEM, ADD_TODO_ITEM } from './Actions.Types';

describe('when todo items reducing is requested', () => {
    it('adds new todo item', () => {
        const item = { id: 1, title: 'title', description: 'description' };
        const action = { type: ADD_TODO_ITEM, payload: item };
        const state = { todos: [] };

        let result = reducer(state, action);

        expect(result.todos.length).toBe(1);
        expect(result.todos[0].title).toBe(item.title);
    });

    it('removes new todo item', () => {
        const item = { id: 1, title: 'title', description: 'description' };
        const action = { type: REMOVE_TODO_ITEM, payload: item.id };
        const state = { todos: [item] };

        let result = reducer(state, action);

        expect(result.todos.length).toBe(0);
    });
});