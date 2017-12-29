package hr.fer.oobl.iorder.iorder.ui.dashboard;

import android.content.Context;
import android.os.Bundle;
import android.support.annotation.NonNull;
import android.support.annotation.Nullable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListAdapter;
import android.widget.ExpandableListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

import javax.inject.Inject;

import butterknife.ButterKnife;
import hr.fer.oobl.iorder.iorder.R;
import hr.fer.oobl.iorder.iorder.base.BaseFragment;
import hr.fer.oobl.iorder.iorder.base.ScopedPresenter;
import hr.fer.oobl.iorder.iorder.injection.fragment.FragmentComponent;
import hr.fer.oobl.iorder.iorder.ui.main.model.CustomExpandableListAdapter;
import hr.fer.oobl.iorder.iorder.ui.main.model.ExpandableListDataPump;

public final class DashboardFragment extends BaseFragment implements DashboardContract.View {

    @Inject
    Context context;

    private ExpandableListView expandableListView;
    private ExpandableListAdapter expandableListAdapter;
    private List<String> expandableListTitle;
    private HashMap<String, List<String>> expandableListDetail;

    public static DashboardFragment newInstance() {
        final DashboardFragment fragment = new DashboardFragment();
        final Bundle args = new Bundle();
        fragment.setArguments(args);
        return fragment;
    }

    @Override
    public View onCreateView(@NonNull final LayoutInflater inflater, final ViewGroup container,
                             Bundle savedInstanceState) {
        return inflater.inflate(R.layout.fragment_menu, container, false);
    }

    @Override
    public void onViewCreated(@NonNull final View view, @Nullable final Bundle savedInstanceState) {
        super.onViewCreated(view, savedInstanceState);
        ButterKnife.bind(this, view);

        expandableListView = view.findViewById(R.id.expandableListView);
        expandableListDetail = ExpandableListDataPump.getData();
        expandableListTitle = new ArrayList<>(expandableListDetail.keySet());
        expandableListAdapter = new CustomExpandableListAdapter(context, expandableListTitle, expandableListDetail);
        expandableListView.setAdapter(expandableListAdapter);
        expandableListView.setOnGroupExpandListener(groupPosition -> Toast.makeText(context,
                                                                            expandableListTitle.get(groupPosition) + " List Expanded.",
                                                                            Toast.LENGTH_SHORT).show());

        expandableListView.setOnGroupCollapseListener(groupPosition -> Toast.makeText(context,
                                                                              expandableListTitle.get(groupPosition) + " List Collapsed.",
                                                                              Toast.LENGTH_SHORT).show());

        expandableListView.setOnChildClickListener((parent, v, groupPosition, childPosition, id) -> {
            Toast.makeText(
                    getActivity().getApplicationContext(),
                    expandableListTitle.get(groupPosition)
                            + " -> "
                            + expandableListDetail.get(
                            expandableListTitle.get(groupPosition)).get(
                            childPosition), Toast.LENGTH_SHORT
            ).show();
            return false;
        });
    }

    @Override
    public ScopedPresenter getPresenter() {
        return null;
    }

    @Override
    protected void inject(final FragmentComponent fragmentComponent) {
        fragmentComponent.inject(this);
    }
}
