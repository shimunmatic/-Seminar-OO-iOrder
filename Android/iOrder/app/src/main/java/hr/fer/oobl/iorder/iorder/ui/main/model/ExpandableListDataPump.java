package hr.fer.oobl.iorder.iorder.ui.main.model;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class ExpandableListDataPump {

    public static HashMap<String, List<String>> getData() {
        HashMap<String, List<String>> expandableListDetail = new HashMap<String, List<String>>();

        List<String> beers = new ArrayList<String>();
        beers.add("Heineken");
        beers.add("Pan");
        beers.add("Karlovačko");
        beers.add("Ožujsko");
        beers.add("Velebitsko");

        List<String> warmDrink = new ArrayList<String>();
        warmDrink.add("Kava s mlijekom");
        warmDrink.add("Ice coffee");
        warmDrink.add("Kakao");
        warmDrink.add("Topla čokolada");
        warmDrink.add("Nescafe vanilija");

        List<String> juices = new ArrayList<String>();
        juices.add("Coca Cola");
        juices.add("Fanta");
        juices.add("Sprite");
        juices.add("Schweppes");
        juices.add("Cockta");

        expandableListDetail.put("Pive", beers);
        expandableListDetail.put("Topli napitci", warmDrink);
        expandableListDetail.put("Gazirani sokovi", juices);
        return expandableListDetail;
    }
}