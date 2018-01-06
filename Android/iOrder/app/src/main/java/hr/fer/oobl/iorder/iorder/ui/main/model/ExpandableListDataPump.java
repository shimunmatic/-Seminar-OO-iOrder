package hr.fer.oobl.iorder.iorder.ui.main.model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import hr.fer.oobl.iorder.data.model.Category;
import hr.fer.oobl.iorder.data.model.Product;

public class ExpandableListDataPump {

    public static HashMap<String, List<Product>> getData() {
        HashMap<String, List<Product>> expandableListDetail = new HashMap<>();

        List<Product> beers = new ArrayList<>();
        beers.add(new Product("Heineken", "16,00"));
        beers.add(new Product("Pan", "12,00"));
        beers.add(new Product("Karlovačko", "12,00"));
        beers.add(new Product("Ožujsko", "10,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));
        beers.add(new Product("Velebitsko", "13,00"));

        List<Product> warmDrinks = new ArrayList<>();
        warmDrinks.add(new Product("Kava s mlijekom", "8,00"));
        warmDrinks.add(new Product("Kakao", "12,00"));
        warmDrinks.add(new Product("Vruća čokolada", "9,00"));
        warmDrinks.add(new Product("Čaj", "10,00"));

        final Category beer = new Category("Beer", beers);
        final Category warmDrink = new Category("Warm drink", warmDrinks);

        expandableListDetail.put(beer.getName(), beer.getProducts());
        expandableListDetail.put(warmDrink.getName(), warmDrink.getProducts());

        return expandableListDetail;
    }
}