package hr.fer.oobl.iorder.iorder.utils;

import java.util.ArrayList;
import java.util.List;

import hr.fer.oobl.iorder.domain.model.Order;

public final class OrderManager {

    private List<Order> orderList = new ArrayList<>();

    public void addOrder(final Order order) {
        orderList.add(order);
    }

    public List<Order> getOrderList() {
        return orderList;
    }
}
